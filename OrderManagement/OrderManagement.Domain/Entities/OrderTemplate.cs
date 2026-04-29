using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class OrderTemplate : BaseEntity<int>
    {
        public int MerchantId { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public bool RequireName { get; set; } = true;
        public bool RequireMobile { get; set; } = true;
        public bool RequireFlatVilla { get; set; } = true;
        public bool RequireSociety { get; set; } = true;
        public bool RequireBlock { get; set; }
        public bool RequireWhatsApp { get; set; }
        public string? CustomFieldsJson { get; set; }   // JSON array of extra fields
        public bool IsDefault { get; set; }

        // Navigation
        public Merchant Merchant { get; set; } = null!;
    }
}
