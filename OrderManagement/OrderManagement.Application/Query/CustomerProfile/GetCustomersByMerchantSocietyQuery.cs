using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.CustomerProfile
{
    public class GetCustomersByMerchantSocietyQuery : IRequest<Result>
    {
        public int MerchantSocietyId { get; set; }
        public GetCustomersByMerchantSocietyQuery(int id) => MerchantSocietyId = id;
    }
}
