using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
    {
        public void Configure(EntityTypeBuilder<CustomerProfile> builder)
        {
            builder.ToTable("CustomerProfiles", "user");
            builder.HasKey(x => x.Id);

            // One customer profile per user per MerchantSociety
            builder.HasIndex(x => new { x.UserId, x.MerchantSocietyId })
                .IsUnique();

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.MobileNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.FlatOrVillaNumber)
                .HasMaxLength(50);

            builder.Property(x => x.Block)
                .HasMaxLength(50);

            builder.Property(x => x.WhatsAppId)
                .HasMaxLength(50);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.MerchantSociety)
                .WithMany(x => x.CustomerProfiles)
                .HasForeignKey(x => x.MerchantSocietyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
