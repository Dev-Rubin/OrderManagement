using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class RefreshToken : BaseEntity<int>
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        public User User { get; set; }
    }
}
