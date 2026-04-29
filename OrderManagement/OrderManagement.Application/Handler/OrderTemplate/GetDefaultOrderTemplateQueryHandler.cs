using MediatR;
using OrderManagement.Application.Query.OrderTemplate;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.OrderTemplate
{
    public class GetDefaultOrderTemplateQueryHandler(IOrderTemplateService s) : IRequestHandler<GetDefaultOrderTemplateQuery, Result>
    { 
        public Task<Result> Handle(GetDefaultOrderTemplateQuery r, CancellationToken _) => s.GetDefaultAsync(r.MerchantId); 
    }
}
