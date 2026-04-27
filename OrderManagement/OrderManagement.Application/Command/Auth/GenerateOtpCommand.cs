using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Auth
{
    public record GenerateOtpCommand(string PhoneOrEmail, string Otp, bool IsEmail) : IRequest<Result>;
}
