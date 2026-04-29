using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IOrderStatusHistoryQuery : IQueryBuilder<OrderStatusHistory, int>
    {
        IOrderStatusHistoryQuery WhereOrderIdIs(int orderId);
        IOrderStatusHistoryQuery IncludeChangedByUser();
    }
}
