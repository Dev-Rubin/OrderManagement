using MediatR;
using OrderManagement.Application.Query.CustomerProfile;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.CustomerProfile
{
    public class GetCustomerOrderHistoryQueryHandler(ICustomerProfileService s) : IRequestHandler<GetCustomerOrderHistoryQuery, Result>
    { 
        public Task<Result> Handle(GetCustomerOrderHistoryQuery r, CancellationToken _) => s.GetOrderHistoryAsync(r.CustomerProfileId); 
    }
}
