using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class MerchantSocietyConfiguration : IEntityTypeConfiguration<MerchantSociety>
    {
        public void Configure(EntityTypeBuilder<MerchantSociety> builder)
        {
            builder.ToTable("MerchantSocieties", "user");
            builder.HasKey(x => x.Id);

            // Unique constraint — a merchant can only be linked to a society once
            builder.HasIndex(x => new { x.MerchantId, x.SocietyId })
                .IsUnique();

            builder.Property(x => x.DeliveryInstructions)
                .HasMaxLength(500);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.MerchantSociety)
                .HasForeignKey(x => x.MerchantSocietyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.CustomerProfiles)
                .WithOne(x => x.MerchantSociety)
                .HasForeignKey(x => x.MerchantSocietyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
