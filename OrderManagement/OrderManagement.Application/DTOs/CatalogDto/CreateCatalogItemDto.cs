namespace OrderManagement.Application.DTOs.CatalogDto
{
    public class CreateCatalogItemDto
    {
        public int? ProductId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Quantity { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int SortOrder { get; set; }
    }

}
