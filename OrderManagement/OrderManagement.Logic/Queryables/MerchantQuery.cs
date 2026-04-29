using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class MerchantQuery : QueryBuilder<Merchant, int>, IMerchantQuery
    {
        public MerchantQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IMerchantQuery WhereActive()
        {
            Where(x => x.IsActive);
            return this;
        }

        public IMerchantQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }
    }

}
