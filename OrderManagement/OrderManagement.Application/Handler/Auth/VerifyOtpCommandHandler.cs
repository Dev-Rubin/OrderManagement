using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Auth
{
    internal class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, Result>
    {
        private readonly IOtpService _repo;

        public VerifyOtpCommandHandler(IOtpService repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            return await _repo.VerifyOtpAsync(request);
        }
    }
}
