using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class MerchantSociety : BaseEntity<int>
    {
        public int MerchantId { get; set; }
        public int SocietyId { get; set; }
        public bool IsActive { get; set; } = true;
        public string? DeliveryInstructions { get; set; }

        // Navigation
        public Merchant Merchant { get; set; } = null!;
        public Society Society { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<CustomerProfile> CustomerProfiles { get; set; } = [];
    }
}
