using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Quantity)
                .HasMaxLength(50);

            builder.Property(x => x.PresentCost)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.RevisedCost)
                .HasColumnType("decimal(10,2)")
                .IsRequired(false);

            builder.Ignore(x => x.EffectiveCost); // computed, not stored

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasData(
                // Batters
                new Product { Id = 1, CategoryId = 1, Name = "Idly Dosa Batter", Quantity = "1 kg", PresentCost = 70, RevisedCost = null },
                new Product { Id = 2, CategoryId = 1, Name = "Appam Batter", Quantity = "1 kg", PresentCost = 100, RevisedCost = null },
                new Product { Id = 3, CategoryId = 1, Name = "4 Millets", Quantity = "1 kg", PresentCost = 140, RevisedCost = null },
                new Product { Id = 4, CategoryId = 1, Name = "Pesarat Dosa", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 5, CategoryId = 1, Name = "Rava Dosa", Quantity = "1 kg", PresentCost = 100, RevisedCost = null },
                new Product { Id = 6, CategoryId = 1, Name = "Paddu / Paniyaram Batter", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 7, CategoryId = 1, Name = "Udin Vada Batter", Quantity = "500 gms", PresentCost = 100, RevisedCost = null },
                new Product { Id = 8, CategoryId = 1, Name = "Red Rice", Quantity = "1 kg", PresentCost = 100, RevisedCost = null },
                new Product { Id = 9, CategoryId = 1, Name = "Ragi Dosa", Quantity = "1 kg", PresentCost = 100, RevisedCost = null },
                new Product { Id = 10, CategoryId = 1, Name = "Banana Stem Batter", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 11, CategoryId = 1, Name = "Moringa Dosa", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 12, CategoryId = 1, Name = "Palak Dosa Batter", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 13, CategoryId = 1, Name = "Peanut Dosa Batter", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 14, CategoryId = 1, Name = "Curry Leaf Dosa", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 15, CategoryId = 1, Name = "Multi Dhal / Adai Batter", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 16, CategoryId = 1, Name = "Garlic Dosa Batter", Quantity = "1 kg", PresentCost = 120, RevisedCost = null },
                new Product { Id = 17, CategoryId = 1, Name = "Wheat Dosa Batter", Quantity = "1 kg", PresentCost = 100, RevisedCost = null },

                // Accompaniments
                new Product { Id = 18, CategoryId = 2, Name = "Coconut Chutney", Quantity = "100gms", PresentCost = 30, RevisedCost = null },
                new Product { Id = 19, CategoryId = 2, Name = "Peanut Chutney", Quantity = "100gms", PresentCost = 30, RevisedCost = 35 },
                new Product { Id = 20, CategoryId = 2, Name = "Tomato Chutney", Quantity = "100gms", PresentCost = 30, RevisedCost = 35 },
                new Product { Id = 21, CategoryId = 2, Name = "Garlic Chutney", Quantity = "100gms", PresentCost = 35, RevisedCost = 40 },
                new Product { Id = 22, CategoryId = 2, Name = "Onion Chutney", Quantity = "100gms", PresentCost = 30, RevisedCost = 35 },
                new Product { Id = 23, CategoryId = 2, Name = "Mint Chutney", Quantity = "100gms", PresentCost = 30, RevisedCost = 35 },
                new Product { Id = 24, CategoryId = 2, Name = "Chennai Tiffin Sambar", Quantity = "300gms", PresentCost = 30, RevisedCost = 35 },
                new Product { Id = 25, CategoryId = 2, Name = "Coconut Milk", Quantity = "300gms", PresentCost = 100, RevisedCost = null },
                new Product { Id = 26, CategoryId = 2, Name = "Kadala Curry", Quantity = "350gms", PresentCost = 100, RevisedCost = 105 },

                // Ready to Eats
                new Product { Id = 27, CategoryId = 3, Name = "Plain Sevai", Quantity = "500gms", PresentCost = 100, RevisedCost = null },
                new Product { Id = 28, CategoryId = 3, Name = "Idiyappam", Quantity = "1 no", PresentCost = 15, RevisedCost = null },
                new Product { Id = 29, CategoryId = 3, Name = "Regular Idly", Quantity = "1 no", PresentCost = 10, RevisedCost = 12 },
                new Product { Id = 30, CategoryId = 3, Name = "Puttu / 1 Cylinder", Quantity = "1 no", PresentCost = 80, RevisedCost = 90 },
                new Product { Id = 31, CategoryId = 3, Name = "Mini Podi Idly", Quantity = "30 nos", PresentCost = 100, RevisedCost = 105 },
                new Product { Id = 32, CategoryId = 3, Name = "Mini Idly Sambar", Quantity = "30 nos", PresentCost = 100, RevisedCost = 105 },
                new Product { Id = 33, CategoryId = 3, Name = "Lemon Sevai", Quantity = "250gms", PresentCost = 75, RevisedCost = 85 },
                new Product { Id = 34, CategoryId = 3, Name = "Coconut Sevai", Quantity = "250gms", PresentCost = 100, RevisedCost = 105 },
                new Product { Id = 35, CategoryId = 3, Name = "Tomato Sevai", Quantity = "250gms", PresentCost = 100, RevisedCost = 105 },
                new Product { Id = 36, CategoryId = 3, Name = "Garlic Sevai", Quantity = "250gms", PresentCost = 100, RevisedCost = 105 },
                new Product { Id = 37, CategoryId = 3, Name = "Sweet Sevai", Quantity = "250gms", PresentCost = 100, RevisedCost = 105 },
                new Product { Id = 38, CategoryId = 3, Name = "Puliyogare Sevai", Quantity = "250gms", PresentCost = 100, RevisedCost = 105 },

                // Tiffin Items
                new Product { Id = 39, CategoryId = 4, Name = "Masal Dosa (with Sambar & Chutney)", Quantity = "1", PresentCost = 65, RevisedCost = 70 },
                new Product { Id = 40, CategoryId = 4, Name = "Puri with Kurma - 3 Pieces", Quantity = "1", PresentCost = 80, RevisedCost = 90 },
                new Product { Id = 41, CategoryId = 4, Name = "Chapathi", Quantity = "1", PresentCost = 15, RevisedCost = null },
                new Product { Id = 42, CategoryId = 4, Name = "Sunday Fuel - Pongal, Vada with Sambar & Chutney (Sunday only)", Quantity = "1", PresentCost = 80, RevisedCost = 85 },
                new Product { Id = 43, CategoryId = 4, Name = "Thatte Idly, Vada with Sambar & Chutney (Saturday only)", Quantity = "1", PresentCost = 60, RevisedCost = 65 },

                // Podis
                new Product { Id = 44, CategoryId = 5, Name = "Sambar Podi", Quantity = "200gms", PresentCost = 160, RevisedCost = null },
                new Product { Id = 45, CategoryId = 5, Name = "Idili/Dosa Podi", Quantity = "200gms", PresentCost = 160, RevisedCost = null },
                new Product { Id = 46, CategoryId = 5, Name = "Gunpowder Podi", Quantity = "100gms", PresentCost = 80, RevisedCost = null },
                new Product { Id = 47, CategoryId = 5, Name = "Groundnut Podi", Quantity = "100gms", PresentCost = 80, RevisedCost = null },

                // Add Ons
                new Product { Id = 48, CategoryId = 6, Name = "Grated Coconut", Quantity = "200gms", PresentCost = 160, RevisedCost = 160 },

                // Sweet & Namkeen
                new Product { Id = 49, CategoryId = 7, Name = "Adhirasam (Kajaya)", Quantity = "Pack of 4", PresentCost = 60, RevisedCost = 65 },
                new Product { Id = 50, CategoryId = 7, Name = "Thengapal Muruku (Big)", Quantity = "Pack of 2", PresentCost = 60, RevisedCost = 65 }
            );
        }
    }
}
