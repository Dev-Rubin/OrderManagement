using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Catalog
{
    public class DeleteCatalogCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public DeleteCatalogCommand(int id) => Id = id;
    }
}
