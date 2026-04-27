using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.ToTable("Payments", "order");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Currency)
                  .HasMaxLength(10)
                  .HasDefaultValue("INR");

            entity.Property(e => e.Status)
                  .HasMaxLength(20)
                  .HasDefaultValue("Pending");

            entity.Property(e => e.RazorpayOrderId)
                  .HasMaxLength(100);

            entity.Property(e => e.RazorpayPaymentId)
                  .HasMaxLength(100);

            entity.Property(e => e.PaymentLinkId)
                  .HasMaxLength(100);

            entity.Property(e => e.PaymentLinkUrl)
                  .HasMaxLength(500);

            entity.Property(e => e.FailureReason)
                  .HasMaxLength(500);

            entity.Property(e => e.RetryCount)
                  .HasDefaultValue(0);

            entity.Property(e => e.AddedDate)
                  .HasDefaultValueSql("NOW()");

            entity.Property(e => e.IsDeleted)
                  .HasDefaultValue(false);

            entity.HasOne(e => e.Order)
                  .WithMany(o => o.Payments)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            entity.HasIndex(e => e.PaymentLinkId);
            entity.HasIndex(e => e.OrderId);
        }
    }
}
