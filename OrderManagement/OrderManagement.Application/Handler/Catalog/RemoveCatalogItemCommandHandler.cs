using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class RemoveCatalogItemCommandHandler(ICatalogService s) : IRequestHandler<RemoveCatalogItemCommand, Result>
    { 
        public Task<Result> Handle(RemoveCatalogItemCommand r, CancellationToken _) => s.RemoveItemAsync(r.Id); 
    }
}
