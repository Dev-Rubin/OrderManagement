using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Catalog
{
    public class GetAllCatalogsQuery : IRequest<Result>
    {
        public int? MerchantId { get; set; }
        public DateTime? Date { get; set; }
    }
}
