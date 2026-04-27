using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Auth
{
    public record ChangePasswordCommand(int UserId, string CurrentPassword, string NewPassword) : IRequest<Result>;
}
