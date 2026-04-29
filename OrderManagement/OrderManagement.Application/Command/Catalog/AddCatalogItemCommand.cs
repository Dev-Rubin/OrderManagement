using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Catalog
{
    public class AddCatalogItemCommand : IRequest<Result>
    {
        public int CatalogId { get; set; }
        public int? ProductId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Quantity { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int SortOrder { get; set; }
    }

}