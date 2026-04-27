using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class UserCredential : BaseEntity<int>
    {
        public int UserId { get; private set; }
        public string PasswordHash { get; private set; } = default!;
        public string PasswordSalt { get; private set; } = default!;
        public bool IsBlocked { get; set; }

        // Navigation
        public User User { get; private set; } = default!;

        private UserCredential() { }

        public UserCredential(int userId, string passwordHash, string passwordSalt)
        {
            UserId = userId;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public void UpdatePassword(string hash, string salt)
        {
            PasswordHash = hash;
            PasswordSalt = salt;
        }
    }
}
