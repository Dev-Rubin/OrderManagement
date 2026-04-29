using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface ICatalogQuery : IQueryBuilder<Catalog, int>
    {
        public ICatalogQuery WhereIdIs(int id);
        public ICatalogQuery WhereMerchantIdIs(int merchantId);
        public ICatalogQuery WhereDateIs(DateTime date);
        public ICatalogQuery WhereStatus(CatalogStatus status);
        public ICatalogQuery IncludeItems();
    }
}
