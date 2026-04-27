using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class RefreshTokenQuery : QueryBuilder<RefreshToken, int>, IRefreshTokenQuery
    {
        public RefreshTokenQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IRefreshTokenQuery IncludeUser()
        {
            Include(x => x.User);
            return this;
        }

        public IRefreshTokenQuery WhereTokenIs(string token)
        {
            Where(x => x.Token == token);
            return this;
        }
    }
}
