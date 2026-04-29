using MediatR;
using OrderManagement.Application.Query.MerchantSociety;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.MerchantSociety
{
    public class GetSocietiesByMerchantQueryHandler(IMerchantSocietyService s) : IRequestHandler<GetSocietiesByMerchantQuery, Result>
    { 
        public Task<Result> Handle(GetSocietiesByMerchantQuery r, CancellationToken _) => s.GetByMerchantAsync(r.MerchantId);
    }
}
