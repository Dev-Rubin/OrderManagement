namespace OrderManagement.Application.DTOs.MerchantSocietyDto
{
    public class LinkMerchantSocietyDto
    {
        public int MerchantId { get; set; }
        public int SocietyId { get; set; }
        public string? DeliveryInstructions { get; set; }
    }
}
