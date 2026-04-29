using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class CustomerProfile : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int MerchantSocietyId { get; set; }

        // Order template fields
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string? FlatOrVillaNumber { get; set; }
        public string? Block { get; set; }
        public string? WhatsAppId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastOrderAt { get; set; }
        public int TotalOrders { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public MerchantSociety MerchantSociety { get; set; } = null!;
    }
}
