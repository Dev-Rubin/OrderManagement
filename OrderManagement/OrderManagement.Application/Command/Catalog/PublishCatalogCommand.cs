using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Catalog
{
    public class PublishCatalogCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public PublishCatalogCommand(int id) => Id = id;
    }
}
