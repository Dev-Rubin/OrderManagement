using MediatR;
using OrderManagement.Application.Query.CustomerProfile;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.CustomerProfile
{
    public class GetCustomersByMerchantSocietyQueryHandler(ICustomerProfileService s) : IRequestHandler<GetCustomersByMerchantSocietyQuery, Result>
    { 
        public Task<Result> Handle(GetCustomersByMerchantSocietyQuery r, CancellationToken _) => s.GetByMerchantSocietyAsync(r.MerchantSocietyId);
    }
}
