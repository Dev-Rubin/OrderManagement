using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Auth
{
    internal class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IUserRepository _repo;

        public ChangePasswordCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ChangePasswordAsync(request);
        }
    }
}
