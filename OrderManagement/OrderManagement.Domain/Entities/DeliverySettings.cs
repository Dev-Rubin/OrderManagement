using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class DeliverySettings : BaseEntity<int>
    {
        public int Id { get; set; }
        public decimal MinDeliveryCharge { get; set; }   // 25
        public decimal MaxDeliveryCharge { get; set; }   // 40
        public decimal MinParcelCharge { get; set; }     // 5
        public decimal MaxParcelCharge { get; set; }     // 15
    }
}
