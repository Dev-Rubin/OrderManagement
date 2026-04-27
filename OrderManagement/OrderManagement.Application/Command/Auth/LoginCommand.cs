using MediatR;
using OrderManagement.Application.Response;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Auth
{
    public record LoginCommand(string UserName, string Password) : IRequest<Result<AuthResponseDto>>;
}
