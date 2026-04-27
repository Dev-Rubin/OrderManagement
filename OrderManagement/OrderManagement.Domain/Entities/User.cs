using OrderManagement.Domain.Entities.Common;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; private set; } = default!;
        public string Email { get; private set; } = default!; 
        public string PhoneNumber { get; set; }
        public string? WhatsAppId { get; set; }        
        public DateTime LastActiveAt { get; set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Order> Orders { get; set; }

        // Navigation
        public UserCredential Credential { get; private set; } = default!;

        private User() { }

        public User(string userName, string email, string phoneNo,UserRole role)
        {
            UserName = userName;
            Email = email;
            Role = role;
            IsActive = true;
            PhoneNumber = phoneNo;
        }

        public void SetCredential(string passwordHash, string passwordSalt)
        {
            Credential = new UserCredential(Id, passwordHash, passwordSalt);
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
