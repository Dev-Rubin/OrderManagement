using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;   // "1 kg", "500gms", "1 no", etc.
        public decimal PresentCost { get; set; }
        public decimal? RevisedCost { get; set; }              // null = No Change
        public decimal EffectiveCost => RevisedCost ?? PresentCost;

        public Category Category { get; set; } = null!;
    }
}