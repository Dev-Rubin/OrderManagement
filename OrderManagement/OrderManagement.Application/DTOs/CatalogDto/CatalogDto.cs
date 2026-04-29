namespace OrderManagement.Application.DTOs.CatalogDto
{
    public class CatalogDto
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string MerchantName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CatalogDate { get; set; }
        public DateTime? ScheduledPublishAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? WhatsAppMessageTemplate { get; set; }
        public List<CatalogItemDto> Items { get; set; } = [];
    }
}
