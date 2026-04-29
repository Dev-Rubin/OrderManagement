namespace OrderManagement.Application.DTOs.MerchantSocietyDto
{
    public class MerchantSocietyDto
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string MerchantName { get; set; } = string.Empty;
        public int SocietyId { get; set; }
        public string SocietyName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string? DeliveryInstructions { get; set; }
    }
}
