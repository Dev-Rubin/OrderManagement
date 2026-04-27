using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.ToTable("OrderItems", "order");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.ItemName)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(e => e.UnitPrice)
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Remarks)
                  .HasMaxLength(300);

            entity.Property(e => e.AddedDate)
                  .HasDefaultValueSql("NOW()");

            entity.Property(e => e.IsDeleted)
                  .HasDefaultValue(false);

            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderItems)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
