using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens", "user");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token)
                   .IsRequired();

            builder.Property(x => x.ExpiryDate)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(u => u.IsRevoked)
                .HasDefaultValue(false);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId);
        }
    }
}
