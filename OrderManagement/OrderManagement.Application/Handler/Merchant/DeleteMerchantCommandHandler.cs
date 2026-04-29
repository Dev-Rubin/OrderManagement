using MediatR;
using OrderManagement.Application.Command.Merchant;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Merchant
{
    public class DeleteMerchantCommandHandler(IMerchantService s) : IRequestHandler<DeleteMerchantCommand, Result>
    { 
        public Task<Result> Handle(DeleteMerchantCommand r, CancellationToken _) => s.DeleteAsync(r.Id);
    }
}
