using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Catalog
{
    public class GetCatalogByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public GetCatalogByIdQuery(int id) => Id = id;
    }
}
