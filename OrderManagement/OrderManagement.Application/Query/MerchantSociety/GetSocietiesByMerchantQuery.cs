using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.MerchantSociety
{
    public class GetSocietiesByMerchantQuery : IRequest<Result>
    {
        public int MerchantId { get; set; }
        public GetSocietiesByMerchantQuery(int merchantId) => MerchantId = merchantId;
    }
}
