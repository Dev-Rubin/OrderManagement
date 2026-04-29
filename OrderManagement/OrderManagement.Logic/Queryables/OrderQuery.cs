using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class OrderQuery : QueryBuilder<Order, int>, IOrderQuery
    {
        public OrderQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IOrderQuery IncludeItems()
        {
            Include(x => x.OrderItems);
            return this;
        }

        public IOrderQuery WhereMerchantSocietyIdIs(int merchantSocietyId)
        {
            Where (x => x.MerchantSocietyId == merchantSocietyId);
            return this;
        }

        public IOrderQuery WhereUserIdIs(int userId)
        {
            Where(x => x.UserId == userId);
            return this;
        }
    }
}
