namespace OrderManagement.Application.DTOs.MerchantSocietyDto
{
    public class UpdateMerchantSocietyDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? DeliveryInstructions { get; set; }
    }
}
