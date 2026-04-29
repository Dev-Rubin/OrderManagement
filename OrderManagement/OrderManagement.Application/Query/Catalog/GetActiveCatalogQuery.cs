using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Catalog
{
    public class GetActiveCatalogQuery : IRequest<Result>
    {
        public int MerchantId { get; set; }
        public GetActiveCatalogQuery(int merchantId) => MerchantId = merchantId;
    }
}
