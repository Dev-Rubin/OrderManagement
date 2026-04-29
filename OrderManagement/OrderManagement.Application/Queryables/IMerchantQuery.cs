using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IMerchantQuery : IQueryBuilder<Merchant, int>
    {
        public IMerchantQuery WhereIdIs(int id);
        public IMerchantQuery WhereActive();
    }
}
