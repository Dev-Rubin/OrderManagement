using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IOrderTemplateQuery : IQueryBuilder<OrderTemplate, int>
    {
        IOrderTemplateQuery WhereIdIs(int id);
        IOrderTemplateQuery WhereMerchantIdIs(int merchantId);
        IOrderTemplateQuery WhereIsDefault();
    }
}
