using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class AddCatalogItemCommandHandler(ICatalogService s) : IRequestHandler<AddCatalogItemCommand, Result>
    { 
        public Task<Result> Handle(AddCatalogItemCommand r, CancellationToken _) => s.AddItemAsync(r); 
    }
}
