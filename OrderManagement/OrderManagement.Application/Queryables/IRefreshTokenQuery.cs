using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IRefreshTokenQuery : IQueryBuilder<RefreshToken, int>
    {
        public IRefreshTokenQuery WhereTokenIs(string token);
        public IRefreshTokenQuery IncludeUser();
    }
}
