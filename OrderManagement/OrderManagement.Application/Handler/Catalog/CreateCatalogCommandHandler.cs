using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class CreateCatalogCommandHandler(ICatalogService s) : IRequestHandler<CreateCatalogCommand, Result>
    { 
        public Task<Result> Handle(CreateCatalogCommand r, CancellationToken _) => s.CreateAsync(r); 
    }
}
