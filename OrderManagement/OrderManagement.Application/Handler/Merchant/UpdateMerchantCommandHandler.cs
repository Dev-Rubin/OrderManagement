using MediatR;
using OrderManagement.Application.Command.Merchant;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Merchant
{
    public class UpdateMerchantCommandHandler(IMerchantService s) : IRequestHandler<UpdateMerchantCommand, Result>
    { 
        public Task<Result> Handle(UpdateMerchantCommand r, CancellationToken _) => s.UpdateAsync(r);
    }
}
