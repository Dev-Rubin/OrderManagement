using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Orders", "order");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.OrderNumber)
                  .IsRequired()
                  .HasMaxLength(30);

            entity.HasIndex(e => e.OrderNumber)
                  .IsUnique();

            entity.Property(o => o.Status)
                  .HasConversion<string>()
                  .HasMaxLength(30)
                  .HasDefaultValue(OrderStatus.Pending);

            entity.Property(e => e.TotalAmount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Notes)
                  .HasMaxLength(500);

            entity.Property(e => e.CancellationReason)
                  .HasMaxLength(500);

            entity.Property(e => e.AddedDate)
                   .HasDefaultValueSql("NOW()");

            entity.Property(e => e.IsDeleted)
                  .HasDefaultValue(false);

            // Relationship
            entity.HasOne(e => e.User)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(e => e.UserId);

            entity.HasIndex(e => e.Status)
                  .HasFilter("\"IsDeleted\" = false");

            entity.HasIndex(e => e.AddedDate)
                  .HasFilter("\"IsDeleted\" = false");
        }
    }
}
