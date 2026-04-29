using MediatR;
using OrderManagement.Application.Query.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class GetCatalogByIdQueryHandler(ICatalogService s) : IRequestHandler<GetCatalogByIdQuery, Result>
    { 
        public Task<Result> Handle(GetCatalogByIdQuery r, CancellationToken _) => s.GetByIdAsync(r.Id);
    }
}
