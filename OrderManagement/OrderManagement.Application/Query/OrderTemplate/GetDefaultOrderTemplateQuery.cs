using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.OrderTemplate
{
    public class GetDefaultOrderTemplateQuery : IRequest<Result>
    {
        public int MerchantId { get; set; }
        public GetDefaultOrderTemplateQuery(int merchantId) => MerchantId = merchantId;
    }
}
