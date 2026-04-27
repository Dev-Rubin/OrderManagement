using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    // CategoryConfiguration.cs
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Category { Id = 1, Name = "Batters" },
                new Category { Id = 2, Name = "Accompaniments" },
                new Category { Id = 3, Name = "Ready to Eats" },
                new Category { Id = 4, Name = "Tiffin Items" },
                new Category { Id = 5, Name = "Podis" },
                new Category { Id = 6, Name = "Add Ons" },
                new Category { Id = 7, Name = "Sweet & Namkeen" }
            );
        }
    }
}
