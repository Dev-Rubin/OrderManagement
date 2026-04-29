using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class DeleteCatalogCommandHandler(ICatalogService s) : IRequestHandler<DeleteCatalogCommand, Result>
    { 
        public Task<Result> Handle(DeleteCatalogCommand r, CancellationToken _) => s.DeleteAsync(r.Id); 
    }
}
