using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IUserOtpQuery : IQueryBuilder<UserOtp, int>
    {
        IUserQuery WhereIdIs(int id);
    }
}
