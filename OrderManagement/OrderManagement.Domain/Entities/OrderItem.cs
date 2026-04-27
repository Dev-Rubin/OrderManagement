using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public Order Order { get; set; }
    }
}
