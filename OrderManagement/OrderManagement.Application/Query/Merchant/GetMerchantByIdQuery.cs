using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Merchant
{
    public class GetMerchantByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public GetMerchantByIdQuery(int id) => Id = id;
    }
}
