using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class UpdateCatalogCommandHandler(ICatalogService s) : IRequestHandler<UpdateCatalogCommand, Result>
    { 
        public Task<Result> Handle(UpdateCatalogCommand r, CancellationToken _) => s.UpdateAsync(r);
    }
}
