using OrderManagement.Application.Command.Auth;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IOtpService
    {
        Task<Result> GenerateOtpAsync(GenerateOtpCommand request);
        Task<Result> VerifyOtpAsync(VerifyOtpCommand request);
    }
}
