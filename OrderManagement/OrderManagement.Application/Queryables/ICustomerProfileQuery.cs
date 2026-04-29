using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface ICustomerProfileQuery : IQueryBuilder<CustomerProfile, int>
    {
         ICustomerProfileQuery WhereIdIs(int id);
         ICustomerProfileQuery WhereUserIdIs(int userId);
         ICustomerProfileQuery WhereMerchantSocietyIdIs(int merchantSocietyId);
         ICustomerProfileQuery WhereActive();
         ICustomerProfileQuery IncludeMerchantSociety();
    }
}
