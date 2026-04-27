using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Configuration;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace OrderManagement.Logic.Repository
{
    public class OtpService : BasicCrudService<UserOtp, int>, IOtpService
    {
        private readonly IConfiguration _config;
        private readonly OtpSettings _settings;
        private readonly HttpClient _http;
        private TransactionChain _transactionChain;
        public OtpService(IAppDbContext appDbContext, IConfiguration config, IUnitOfWork unitOfWork, IRepository repository, IQueries queries, IHttpClientFactory httpClientFactory) : base(unitOfWork, repository, queries)
        {
            _config = config;
            _settings = new OtpSettings();
            _config.GetSection("OtpSettings").Bind(_settings);
            _http = httpClientFactory.CreateClient("SmsClient"); ;
            _transactionChain  = new TransactionChain(unitOfWork);
        }

        private string GenerateSecureOtp(int length)
        {
            var bytes = new byte[length];
            RandomNumberGenerator.Fill(bytes);

            return string.Concat(bytes.Select(b => (b % 10).ToString()));
        }

        private async Task SendEmailAsync(string email, string subject, string body)
        {
            var smtp = new SmtpClient(_settings.Email.SmtpHost, _settings.Email.Port)
            {
                Credentials = new NetworkCredential(
                    _settings.Email.UserName,
                    _settings.Email.Password),
                EnableSsl = true
            };

            var mail = new MailMessage(
                _settings.Email.From,
                email,
                subject,
                body);

            await smtp.SendMailAsync(mail);
        }

        private async Task SendSmsAsync(string phoneNumber, string message)
        {
            var payload = new
            {
                to = phoneNumber,
                message,
                sender = _settings.Sms.SenderId
            };

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload)
                , System.Text.Encoding.UTF8, "application/json"
            );
            await _http.PostAsync(_settings.Sms.ApiUrl, content);
        }

        public async Task<Result> GenerateOtpAsync(GenerateOtpCommand request)
        {
            string otp;
            DateTime expairesAt = DateTime.UtcNow.AddMinutes(5);
            if (request.IsEmail)
            {
                var user = await Queries.New<IUserQuery>()
                    .IncludeCredential()
                    .WhereEmailIs(request.PhoneOrEmail)
                    .GetLastOrDefaultAsync();

                if (user == null) return Result.Failure($"User not found for this {request.PhoneOrEmail} email.");
                {
                    otp = GenerateSecureOtp(6);
                    var entity = new UserOtp
                    {
                        UserId = user.Id,
                        OtpCode = otp,
                        ExpiresAt = expairesAt,
                        IsUsed = false
                    };

                    _transactionChain = await Transact.ExecuteWithTransactionAsync(
                        () =>
                        {
                            Repository.SaveUpdate(entity);
                        }, "Otp generated successfully.", "Failed to generate otp."
                    ).ConfigureAwait(false);
                }

            }
            else
            {
                var user = await Queries.New<IUserQuery>()
                    .IncludeCredential()
                    .WherePhoneIs(request.PhoneOrEmail)
                    .GetLastOrDefaultAsync();

                if (user == null) return Result.Failure($"User not found for this {request.PhoneOrEmail} phone number.");
                {
                    otp = GenerateSecureOtp(6);
                    var entity = new UserOtp
                    {
                        UserId = user.Id,
                        OtpCode = otp,
                        ExpiresAt = expairesAt,
                        IsUsed = false
                    };

                    _transactionChain = await Transact.ExecuteWithTransactionAsync(
                        () =>
                        {
                            Repository.SaveUpdate(entity);
                        }, "Otp generated successfully.", "Failed to generate otp."
                    ).ConfigureAwait(false);
                }
            }
            return new Result(_transactionChain.Result.IsSuccessful, _transactionChain.Result.Message, data : new { otp = otp, ExpiresAt = expairesAt });
        }

        public async Task<Result> VerifyOtpAsync(VerifyOtpCommand request)
        {
            var record = await Queries.New<IUserOtpQuery>()
                .Where(x=> x.OtpCode == request.Otp &&
                    !x.IsUsed &&
                    x.ExpiresAt > DateTime.UtcNow
                ).OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (record == null) return Result.Failure("Invalid or expired OTP.");

            record.IsUsed = true;
            await UnitOfWork.SaveAsync();

            return Result.Success("OTP verified successfully.", new { UserId  = record.UserId});
        }

    }
}
