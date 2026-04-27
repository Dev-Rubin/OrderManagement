using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Application.Response;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Persistence.Persistence.Common;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Repository
{
    public class UserRepository : BasicCrudService<User, int>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public UserRepository(AppDbContext context, IUnitOfWork unitOfWork, IRepository repository, IQueries queries, IPasswordHasher hasher, IJwtTokenGenerator tokenGenerator) : base(unitOfWork, repository, queries)
        {
            _context = context;
            _hasher = hasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await Queries.New<IUserQuery>()
                .WhereNameIs(userName)
                .GetLastOrDefaultAsync();  
        }

        public async Task<Result<AuthResponseDto>> LoginUserAsync(LoginCommand cmd)
        {
            var user = await Queries.New<IUserQuery>()
                .IncludeCredential()
                .WhereNameIs(cmd.UserName)
                .GetLastOrDefaultAsync(); 

            if (user == null || !user.IsActive || user.Credential == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var isValid = _hasher.Verify(
                cmd.Password,
                user.Credential.PasswordHash,
                user.Credential.PasswordSalt
            );

            if (!isValid)
                throw new UnauthorizedAccessException("Invalid credentials");

            return await _tokenGenerator.GenerateAsync(user);
        }

        public async Task<Result> RegisterUserAsync(RegisterUserCommand cmd)
        {

            var user = await Queries.New<IUserQuery>()
                .WhereEmailIs(cmd.Email)
                .GetLastOrDefaultAsync();

            if(user != null)
            {
                return Result.Failure("User with the same email already exists.");
            }

            _hasher.CreatePasswordHash(cmd.Password, out string hash, out string salt);
            user = new User(cmd.UserName, cmd.Email, cmd.PhoneNumber,cmd.UserRole);
            user.SetCredential(hash, salt);

            var result = await Transact.ExecuteWithTransactionAsync(
                () =>
                {
                    Repository.Save(user);
                }, "User registered successfully.", "Failed to register user."
            ).ConfigureAwait(false);

            return new Result(result.Result.IsSuccessful, result.Result.Message);
            
        }

        public async Task<Result> ChangePasswordAsync(ChangePasswordCommand request)
        {
            var user = await Queries.New<IUserQuery>()
                .IncludeCredential()
                .WhereIdIs(request.UserId)
                .GetLastOrDefaultAsync();

            if (user == null || user.Credential == null)
                return Result.Failure("User not found.");

            var isValid = _hasher.Verify(
                request.CurrentPassword,
                user.Credential.PasswordHash,
                user.Credential.PasswordSalt
            );

            if (!isValid)
                return Result.Failure("Current password is incorrect.");
            _hasher.CreatePasswordHash(request.NewPassword, out string newHash, out string newSalt);
            user.SetCredential(newHash, newSalt);
            var result = await Transact.ExecuteWithTransactionAsync(
                () =>
                {
                    Repository.SaveUpdate(user);
                }, "Password changed successfully.", "Failed to change password."
            ).ConfigureAwait(false);

            return new Result(result.Result.IsSuccessful, result.Result.Message);
        }
    }
}
