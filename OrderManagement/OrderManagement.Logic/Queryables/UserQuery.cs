using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    public class UserQuery : QueryBuilder<User, int>, IUserQuery
    {
        public UserQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IUserQuery IncludeCredential()
        {
            Include(x => x.Credential);
            return this;
        }

        public IUserQuery WhereEmailIs(string email)
        {
            Where(x => x.Email == email);
            return this;
        }

        public IUserQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }

        public IUserQuery WhereNameIs(string name)
        {
           Where(x => x.UserName == name);
            return this;
        }
    }
}
