using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class CatalogItem : BaseEntity<int>
    {
        public int CatalogId { get; set; }
        public int? ProductId { get; set; }          // nullable — can be ad-hoc item
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Quantity { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int SortOrder { get; set; }

        // Navigation
        public Catalog Catalog { get; set; } = null!;
        public Product? Product { get; set; }
    }
}
