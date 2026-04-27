using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Auth
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IUserRepository _repo;
        
        public RegisterUserCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {          
            return  await _repo.RegisterUserAsync(request);
        }
    }
}
