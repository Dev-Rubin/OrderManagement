namespace OrderManagement.Application.DTOs.MerchantDto
{
    public class MerchantDto
    {
        public int Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? WhatsAppNumber { get; set; }
        public string? LogoUrl { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public int? AdminUserId { get; set; }
    }
}
