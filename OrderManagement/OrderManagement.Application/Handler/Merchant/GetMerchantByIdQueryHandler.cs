using MediatR;
using OrderManagement.Application.Query.Merchant;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Merchant
{
    public class GetMerchantByIdQueryHandler(IMerchantService s) : IRequestHandler<GetMerchantByIdQuery, Result>
    { 
        public Task<Result> Handle(GetMerchantByIdQuery r, CancellationToken _) => s.GetByIdAsync(r.Id); 
    }
}
