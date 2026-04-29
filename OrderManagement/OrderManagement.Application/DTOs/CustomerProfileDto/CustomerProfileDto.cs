namespace OrderManagement.Application.DTOs.CustomerProfileDto
{
    public class CustomerProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MerchantSocietyId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string? FlatOrVillaNumber { get; set; }
        public string? Block { get; set; }
        public string? WhatsAppId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastOrderAt { get; set; }
        public int TotalOrders { get; set; }
        public string SocietyName { get; set; } = string.Empty;
    }
}
