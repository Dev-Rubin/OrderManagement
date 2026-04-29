using MediatR;
using OrderManagement.Application.Command.Merchant;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Merchant
{
    public class CreateMerchantCommandHandler(IMerchantService s) : IRequestHandler<CreateMerchantCommand, Result>
    {
        public Task<Result> Handle(CreateMerchantCommand r, CancellationToken _) => s.CreateAsync(r);
    }
}
