using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Catalog
{
    public class RemoveCatalogItemCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public RemoveCatalogItemCommand(int id) => Id = id;
    }
}
