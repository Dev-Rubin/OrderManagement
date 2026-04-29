using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.DTOs.CustomerProfileDto
{
    public class OrderDto
    {
        public string OrderNumber { get; set; }
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? AddedDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
