using MediatR;
using OrderManagement.Application.Query.OrderTemplate;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.OrderTemplate
{
    public class GetOrderTemplatesByMerchantQueryHandler(IOrderTemplateService s) : IRequestHandler<GetOrderTemplatesByMerchantQuery, Result>
    { 
        public Task<Result> Handle(GetOrderTemplatesByMerchantQuery r, CancellationToken _) => s.GetByMerchantAsync(r.MerchantId); 
    }
}
