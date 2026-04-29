using OrderManagement.Domain.Entities.Common;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities
{
    public class OrderStatusHistory : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public OrderStatus FromStatus { get; set; }
        public OrderStatus ToStatus { get; set; }
        public string? Remarks { get; set; }
        public int? ChangedByUserId { get; set; }
        public DateTime ChangedAt { get; set; }

        // Navigation
        public Order Order { get; set; } = null!;
        public User? ChangedByUser { get; set; }
    }
}
