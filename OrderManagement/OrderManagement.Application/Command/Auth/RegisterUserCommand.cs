using MediatR;
using OrderManagement.Domain.Enums;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Auth
{
    public record RegisterUserCommand(
        string UserName,
        string Email,
        string Password,
        string PhoneNumber,
        UserRole UserRole = UserRole.Customer
    ) : IRequest<Result>;
}
