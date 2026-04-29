using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Merchant : BaseEntity<int>
    {
        public string BusinessName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? WhatsAppNumber { get; set; }
        public string? LogoUrl { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;

        // The User who manages this merchant (MerchantAdmin role)
        public int? AdminUserId { get; set; }
        public User? AdminUser { get; set; }

        // Navigation
        public ICollection<MerchantSociety> MerchantSocieties { get; set; } = [];
        public ICollection<Catalog> Catalogs { get; set; } = [];
        public ICollection<OrderTemplate> OrderTemplates { get; set; } = [];
    }
}
