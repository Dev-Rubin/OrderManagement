namespace OrderManagement.Application.DTOs.CatalogDto
{
    public class CatalogItemDto
    {
        public int Id { get; set; }
        public int CatalogId { get; set; }
        public int? ProductId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Quantity { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SortOrder { get; set; }
    }
}
