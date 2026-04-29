using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class SocietyConfiguration : IEntityTypeConfiguration<Society>
    {
        public void Configure(EntityTypeBuilder<Society> builder)
        {
            builder.ToTable("Societies", "user");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Area).HasMaxLength(150);
            builder.Property(x => x.PinCode).HasMaxLength(10);

            builder.HasMany(x => x.MerchantSocieties)
                .WithOne(x => x.Society)
                .HasForeignKey(x => x.SocietyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
