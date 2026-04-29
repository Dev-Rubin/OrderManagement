using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.OrderTemplate
{
    public class GetOrderTemplatesByMerchantQuery : IRequest<Result>
    {
        public int MerchantId { get; set; }
        public GetOrderTemplatesByMerchantQuery(int merchantId) => MerchantId = merchantId;
    }
}
