using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Auth
{
    internal class GenerateOtpCommandHandler : IRequestHandler<GenerateOtpCommand, Result>
    {
        private readonly IOtpService _repo;

        public GenerateOtpCommandHandler(IOtpService repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GenerateOtpAsync(request);
        }
    }
}
