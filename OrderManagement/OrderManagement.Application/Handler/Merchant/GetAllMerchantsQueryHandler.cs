using MediatR;
using OrderManagement.Application.Query.Merchant;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Merchant
{
    public class GetAllMerchantsQueryHandler(IMerchantService s) : IRequestHandler<GetAllMerchantsQuery, Result>
    {
        public Task<Result> Handle(GetAllMerchantsQuery r, CancellationToken _) => s.GetAllAsync();
    }
}
