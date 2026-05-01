using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs", "order");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(500);

            builder.Property(x => x.WhatsAppMessageTemplate)
                .HasMaxLength(2000);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Merchant)
                .WithMany(x => x.Catalogs)
                .HasForeignKey(x => x.MerchantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Catalog)
                .HasForeignKey(x => x.CatalogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
