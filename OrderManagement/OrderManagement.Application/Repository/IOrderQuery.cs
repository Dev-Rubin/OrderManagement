using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Repository
{
    public interface IOrderQuery : IQueryBuilder<Order, int>
    {
        IOrderQuery IncludeItems();
        IOrderQuery WhereMerchantSocietyIdIs(int merchantSocietyId);
        IOrderQuery WhereUserIdIs(int userId);
    }
}
