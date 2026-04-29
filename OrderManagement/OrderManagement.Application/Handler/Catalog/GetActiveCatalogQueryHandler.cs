using MediatR;
using OrderManagement.Application.Query.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class GetActiveCatalogQueryHandler(ICatalogService s) : IRequestHandler<GetActiveCatalogQuery, Result>
    { 
        public Task<Result> Handle(GetActiveCatalogQuery r, CancellationToken _) => s.GetActiveAsync(r.MerchantId);
    }
}
