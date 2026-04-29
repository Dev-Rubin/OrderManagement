using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class UpdateCatalogItemCommandHandler(ICatalogService s) : IRequestHandler<UpdateCatalogItemCommand, Result>
    { 
        public Task<Result> Handle(UpdateCatalogItemCommand r, CancellationToken _) => s.UpdateItemAsync(r); 
    }
}
