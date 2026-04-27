using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class UserOtpConfiguration : IEntityTypeConfiguration<UserOtp>
    {
        public void Configure(EntityTypeBuilder<UserOtp> builder)
        {
            // Table Name
            builder.ToTable("UserOtps");

            // Primary Key (already from BaseEntity, but explicit is fine)
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.OtpCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();

            builder.Property(x => x.IsUsed)
                   .HasDefaultValue(false);

            // Relationship
            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Index (IMPORTANT for performance)
            builder.HasIndex(x => new { x.UserId, x.OtpCode });

            builder.HasIndex(x => x.ExpiresAt);

            // Optional: Prevent reuse of active OTP
            builder.HasIndex(x => new { x.UserId, x.IsUsed });
        }
    }
}
