using MediatR;
using OrderManagement.Application.Query.CustomerProfile;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.OrderStatusHistory
{
    public class GetOrderStatusHistoryQueryHandler(IOrderStatusHistoryService s) : IRequestHandler<GetOrderStatusHistoryQuery, Result>
    { 
        public Task<Result> Handle(GetOrderStatusHistoryQuery r, CancellationToken _) => s.GetByOrderIdAsync(r.OrderId); 
    }
}
