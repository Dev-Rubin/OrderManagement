using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class CatalogItemQuery : QueryBuilder<CatalogItem, int>, ICatalogItemQuery
    {
        public CatalogItemQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ICatalogItemQuery WhereCatalogIdIs(int catalogId)
        {
            Where(x => x.CatalogId == catalogId);
            return this;
        }

        public ICatalogItemQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }
    }

}
