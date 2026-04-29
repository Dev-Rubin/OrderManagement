using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.CustomerProfile
{
    public class GetCustomerOrderHistoryQuery : IRequest<Result>
    {
        public int CustomerProfileId { get; set; }
        public GetCustomerOrderHistoryQuery(int id) => CustomerProfileId = id;
    }
}
