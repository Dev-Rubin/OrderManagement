using MediatR;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Catalog
{
    public class PublishCatalogCommandHandler(ICatalogService s) : IRequestHandler<PublishCatalogCommand, Result>
    { 
        public Task<Result> Handle(PublishCatalogCommand r, CancellationToken _) => s.PublishAsync(r.Id); 
    }
}
