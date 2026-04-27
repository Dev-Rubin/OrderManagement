using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entities.Configurations
{
    // DeliverySettingsConfiguration.cs
    public class DeliverySettingsConfiguration : IEntityTypeConfiguration<DeliverySettings>
    {
        public void Configure(EntityTypeBuilder<DeliverySettings> builder)
        {
            builder.ToTable("DeliverySettings", "order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MinDeliveryCharge).HasColumnType("decimal(10,2)");
            builder.Property(x => x.MaxDeliveryCharge).HasColumnType("decimal(10,2)");
            builder.Property(x => x.MinParcelCharge).HasColumnType("decimal(10,2)");
            builder.Property(x => x.MaxParcelCharge).HasColumnType("decimal(10,2)");

            builder.HasData(
                new DeliverySettings { Id = 1, MinDeliveryCharge = 25, MaxDeliveryCharge = 40, MinParcelCharge = 5, MaxParcelCharge = 15 }
            );
        }
    }
}
