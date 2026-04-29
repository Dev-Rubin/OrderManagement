using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface ISocietyQuery : IQueryBuilder<Society, int>
    {
        ISocietyQuery WhereIdIs(int id);
        ISocietyQuery WhereActive();
    }
}
