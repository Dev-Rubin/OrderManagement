using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class UserCredentialConfiguration : IEntityTypeConfiguration<UserCredential>
    {
        public void Configure(EntityTypeBuilder<UserCredential> entity)
        {
            entity.ToTable("UserCredentials", "user");

            // Primary Key
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Id)
                  .ValueGeneratedOnAdd();

            // Foreign Key
            entity.Property(c => c.UserId)
                  .IsRequired();

            entity.HasIndex(c => c.UserId)
                  .IsUnique(); // One-to-One enforcement

            // PasswordHash
            entity.Property(c => c.PasswordHash)
                  .IsRequired()
                  .HasMaxLength(500);

            // PasswordSalt
            entity.Property(c => c.PasswordSalt)
                  .IsRequired()
                  .HasMaxLength(500);

            entity.Property(u => u.IsBlocked)
                  .HasDefaultValue(false);

            // Relationship handled in UserConfiguration (optional duplication avoided)
        }
    }
}
