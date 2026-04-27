using MediatR;
using OrderManagement.Application.Response;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Auth
{
    public record VerifyOtpCommand(string PhoneOrEmail, string Otp, bool IsEmail) : IRequest<Result>;
}
