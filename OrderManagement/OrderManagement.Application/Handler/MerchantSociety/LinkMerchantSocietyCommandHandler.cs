using MediatR;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.MerchantSociety
{
    public class LinkMerchantSocietyCommandHandler(IMerchantSocietyService s) : IRequestHandler<LinkMerchantSocietyCommand, Result>
    { 
        public Task<Result> Handle(LinkMerchantSocietyCommand r, CancellationToken _) => s.LinkAsync(r);
    }
}
