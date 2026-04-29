using OrderManagement.Application.Queryables;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;

namespace OrderManagement.Logic.Queryables
{
    internal class MerchantSocietyQuery : QueryBuilder<MerchantSociety, int>, IMerchantSocietyQuery
    {
        public MerchantSocietyQuery(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IMerchantSocietyQuery WhereMerchantIdIs(int merchantId)
        {
            Where(x => x.MerchantId == merchantId);
            return this;
        }
        public IMerchantSocietyQuery WhereSocietyIdIs(int societyId)
        {
            Where(x => x.SocietyId == societyId);
            return this;
        }

        public IMerchantSocietyQuery WhereIdIs(int id)
        {
            Where(x => x.Id == id);
            return this;
        }
        public IMerchantSocietyQuery WhereActive()
        {
            Where(x => x.IsActive);
            return this;
        }
        public IMerchantSocietyQuery WhereInactive()
        {
            Where(x => !x.IsActive);
            return this;
        }

        public IMerchantSocietyQuery IncludeMerchant()
        {
            Include(x => x.Merchant);
            return this;
        }
        public IMerchantSocietyQuery IncludeSociety()
        {
            Include(x => x.Society);
            return this;
        }
    }
}
