using OrderManagement.Application.Response;
using OrderManagement.Domain.Entities;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IJwtTokenGenerator
    {
        Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken);
        Task<Result<AuthResponseDto>> GenerateAsync(User user);
    }
}
