using MediatR;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.MerchantSociety
{
    public class UpdateMerchantSocietyCommandHandler(IMerchantSocietyService s) : IRequestHandler<UpdateMerchantSocietyCommand, Result>
    { 
        public Task<Result> Handle(UpdateMerchantSocietyCommand r, CancellationToken _) => s.UpdateAsync(r); 
    }
}
