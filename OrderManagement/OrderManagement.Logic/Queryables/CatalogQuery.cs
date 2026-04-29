using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class CatalogQuery : QueryBuilder<Catalog, int>, ICatalogQuery
    {
        public CatalogQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ICatalogQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }
        public ICatalogQuery WhereMerchantIdIs(int merchantId)
        {
            Where(x => x.MerchantId == merchantId);
            return this;
        }

        public ICatalogQuery IncludeItems()
        {
            Include(x => x.Items);
            return this;
        }

        public ICatalogQuery WhereDateIs(DateTime date)
        {
            Where(x => x.AddedDate == date);
            return this;
        }

        public ICatalogQuery WhereStatus(CatalogStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
