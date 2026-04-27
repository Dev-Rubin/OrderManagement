using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManagement.Domain.Entities.Configurations
{
    public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> entity)
        {
            // Table
            entity.ToTable("ExceptionLogs", "error");

            // Primary Key
            entity.HasKey(e => e.Id);

            // Id
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            // Timestamp
            entity.Property(e => e.Timestamp)
                  .IsRequired()
                  .HasDefaultValueSql("NOW()");  

            // Message
            entity.Property(e => e.Message)
                  .IsRequired()
                  .HasMaxLength(1000);

            // StackTrace
            entity.Property(e => e.StackTrace);

            // FileName
            entity.Property(e => e.FileName)
                  .HasMaxLength(255);

            // LineNumber
            entity.Property(e => e.LineNumber)
                  .IsRequired(false);

            // StatusCode
            entity.Property(e => e.StatusCode)
                  .IsRequired();

            // Indexes
            entity.HasIndex(e => e.Timestamp);
            entity.HasIndex(e => e.StatusCode);

            // Composite Index (recommended)
            entity.HasIndex(e => new { e.StatusCode, e.Timestamp });
        }
    }
}
