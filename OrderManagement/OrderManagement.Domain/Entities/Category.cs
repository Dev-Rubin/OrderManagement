using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = [];
    } 
}
