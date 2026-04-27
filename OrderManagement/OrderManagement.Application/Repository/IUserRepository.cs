using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Response;
using OrderManagement.Domain.Entities;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<Result> RegisterUserAsync(RegisterUserCommand cmd);
        Task<Result<AuthResponseDto>> LoginUserAsync(LoginCommand cmd);
    }
}
