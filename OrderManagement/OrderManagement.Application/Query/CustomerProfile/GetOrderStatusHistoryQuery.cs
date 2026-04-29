using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.CustomerProfile
{
    public class GetOrderStatusHistoryQuery : IRequest<Result>
    {
        public int OrderId { get; set; }
        public GetOrderStatusHistoryQuery(int orderId) => OrderId = orderId;
    }
}
