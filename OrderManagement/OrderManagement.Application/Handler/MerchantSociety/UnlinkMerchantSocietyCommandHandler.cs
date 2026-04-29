using MediatR;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.MerchantSociety
{
    public class UnlinkMerchantSocietyCommandHandler(IMerchantSocietyService s) : IRequestHandler<UnlinkMerchantSocietyCommand, Result>
    { 
        public Task<Result> Handle(UnlinkMerchantSocietyCommand r, CancellationToken _) => s.UnlinkAsync(r.Id);
    }
}
