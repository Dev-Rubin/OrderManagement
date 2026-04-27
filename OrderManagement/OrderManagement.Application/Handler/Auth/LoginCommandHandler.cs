using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Repository;
using OrderManagement.Application.Response;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
    {
        private readonly IUserRepository _userRepo;
        public LoginCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userRepo.LoginUserAsync(request);            
        }
    }
}

