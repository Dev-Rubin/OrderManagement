using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Repository;
using OrderManagement.Application.Response;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Auth
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponseDto>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public RefreshTokenCommandHandler(IUserRepository userRepo, IJwtTokenGenerator tokenGenerator)
        {
            _userRepo = userRepo;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<Result<AuthResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _tokenGenerator.RefreshTokenAsync(request.RefreshToken);
        }
    }

}
