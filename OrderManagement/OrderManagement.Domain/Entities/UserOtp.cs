using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class UserOtp :BaseEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public User User { get; set; }
    }
}
