using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IUserQuery : IQueryBuilder<User, int>
    {
        IUserQuery WhereIdIs(int id);
        IUserQuery WhereNameIs(string name);
        IUserQuery WhereEmailIs(string email);
        IUserQuery IncludeCredential();

    }
}
