using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Query.User;
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
        Task<Result> ChangePasswordAsync(ChangePasswordCommand request);
        Task<List<AutoCompleteItem>> GetRolesAutocompleteAsync(GetRolesAutocompleteQuery qry);
    }
}
