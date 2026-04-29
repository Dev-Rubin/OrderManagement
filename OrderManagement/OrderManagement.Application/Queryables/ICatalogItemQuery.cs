using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface ICatalogItemQuery : IQueryBuilder<CatalogItem, int>
    {
        ICatalogItemQuery WhereIdIs(int id);
        ICatalogItemQuery WhereCatalogIdIs(int catalogId);
    }
}
