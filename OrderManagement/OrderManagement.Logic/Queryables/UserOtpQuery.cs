using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class UserOtpQuery : QueryBuilder<UserOtp, int>, IUserOtpQuery
    {
        public UserOtpQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IUserQuery WhereIdIs(int id)
        {
            throw new NotImplementedException();
        }
    }
}
