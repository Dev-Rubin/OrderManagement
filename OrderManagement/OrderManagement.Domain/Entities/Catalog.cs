using OrderManagement.Domain.Entities.Common;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities
{
    public class Catalog : BaseEntity<int>
    {
        public int MerchantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CatalogDate { get; set; }           // The date this catalog is for
        public DateTime? ScheduledPublishAt { get; set; }   // Auto-publish time
        public DateTime? PublishedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public CatalogStatus Status { get; set; } = CatalogStatus.Draft;
        public string? ImageUrl { get; set; }
        public string? WhatsAppMessageTemplate { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation
        public Merchant Merchant { get; set; } = null!;
        public ICollection<CatalogItem> Items { get; set; } = [];
    }
}
