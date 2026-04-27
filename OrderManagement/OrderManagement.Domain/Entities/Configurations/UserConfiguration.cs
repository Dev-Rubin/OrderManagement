using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users", "user");

            // Primary Key
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                  .ValueGeneratedOnAdd();

            // UserName
            entity.Property(u => u.UserName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasIndex(u => u.UserName)
                  .IsUnique();

            // Email
            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.HasIndex(u => u.Email)
                  .IsUnique();

            // Role (Enum → string or int)
            entity.Property(u => u.Role)
                  .HasConversion<string>() // better readability in DB
                  .HasMaxLength(50)
                  .IsRequired();

            // IsActive
            entity.Property(u => u.IsActive)
                  .HasDefaultValue(true);

            // One-to-One relationship
            entity.HasOne(u => u.Credential)
                  .WithOne(c => c.User)
                  .HasForeignKey<UserCredential>(c => c.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Ignore domain methods if needed (optional)
            // entity.Ignore(u => u.SetCredential);
        }
    }
}
