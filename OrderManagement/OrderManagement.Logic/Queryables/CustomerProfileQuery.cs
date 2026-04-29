using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class CustomerProfileQuery : QueryBuilder<CustomerProfile, int>, ICustomerProfileQuery
    {
        public CustomerProfileQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ICustomerProfileQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }

        public ICustomerProfileQuery WhereUserIdIs(int userId)
        {
            Where(x => x.UserId == userId);
            return this;
        }

        public ICustomerProfileQuery WhereMerchantSocietyIdIs(int merchantSocietyId)
        {
            Where(x => x.MerchantSocietyId == merchantSocietyId);
            return this;
        }

        public ICustomerProfileQuery WhereActive()
        {
            Where(x => x.IsActive);
            return this;
        }
        public ICustomerProfileQuery WhereInactive()
        {
            Where(x => x.IsActive);
            return this;
        }
       
        public ICustomerProfileQuery IncludeUser()
        {
            Include(x => x.User);
            return this;
        }
        public ICustomerProfileQuery IncludeMerchantSociety()
        {
            Include(x => x.MerchantSociety);
            return this;
        }
    }
}
