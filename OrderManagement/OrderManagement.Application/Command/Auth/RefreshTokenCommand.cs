using MediatR;
using OrderManagement.Application.Response;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Auth
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<Result<AuthResponseDto>>;
}
