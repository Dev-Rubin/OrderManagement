using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class OrderTemplateConfiguration : IEntityTypeConfiguration<OrderTemplate>
    {
        public void Configure(EntityTypeBuilder<OrderTemplate> builder)
        {
            builder.ToTable("OrderTemplates", "order");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TemplateName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.CustomFieldsJson)
                .HasColumnType("text");

            // Only one default template per merchant
            builder.HasIndex(x => new { x.MerchantId, x.IsDefault })
                .HasFilter("\"IsDefault\" = true")
                .IsUnique();

            builder.HasOne(x => x.Merchant)
                .WithMany(x => x.OrderTemplates)
                .HasForeignKey(x => x.MerchantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
