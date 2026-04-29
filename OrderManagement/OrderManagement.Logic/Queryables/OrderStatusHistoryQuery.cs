using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class OrderStatusHistoryQuery : QueryBuilder<OrderStatusHistory, int>, IOrderStatusHistoryQuery
    {
        public OrderStatusHistoryQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IOrderStatusHistoryQuery WhereOrderIdIs(int orderId)
        {
            Where(x => x.OrderId == orderId);
            return this;
        }

        public IOrderStatusHistoryQuery IncludeChangedByUser()
        {
            Include(x => x.ChangedByUser);
            return this;
        }
    }
}
