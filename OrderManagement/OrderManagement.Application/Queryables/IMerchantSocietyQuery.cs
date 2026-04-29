using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Application.Queryables
{
    public interface IMerchantSocietyQuery :  IQueryBuilder<MerchantSociety, int>
    {
        IMerchantSocietyQuery WhereIdIs(int id);
        IMerchantSocietyQuery WhereMerchantIdIs(int merchantId);
        IMerchantSocietyQuery WhereSocietyIdIs(int societyId);
        IMerchantSocietyQuery WhereActive();
        IMerchantSocietyQuery IncludeMerchant();
        IMerchantSocietyQuery IncludeSociety();
    }
}
