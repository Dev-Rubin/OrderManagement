namespace OrderManagement.Application.DTOs.CustomerProfileDto
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
