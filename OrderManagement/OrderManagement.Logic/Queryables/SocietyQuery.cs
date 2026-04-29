using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class SocietyQuery : QueryBuilder<Society, int>, ISocietyQuery
    {
        public SocietyQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ISocietyQuery WhereActive()
        {
            Where(x => x.IsActive);
            return this;
        }

        public ISocietyQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }
    }
}
