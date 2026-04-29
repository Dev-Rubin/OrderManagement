using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class OrderTemplateQuery : QueryBuilder<OrderTemplate, int>, IOrderTemplateQuery
    {
        public OrderTemplateQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IOrderTemplateQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }

        public IOrderTemplateQuery WhereMerchantIdIs(int merchantId)
        {
            Where(x => x.MerchantId == merchantId);
            return this;
        }

        public IOrderTemplateQuery WhereIsDefault()
        {
            Where(x => x.IsDefault);
            return this;
        }
    }
}
