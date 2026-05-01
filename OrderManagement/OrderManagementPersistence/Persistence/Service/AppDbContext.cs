
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Entities.Common;
using OrderManagement.Domain.Entities.Configurations;
using OrderManagement.Infrastructure.Persistence.Interface;
using System.Data;

namespace OrderManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider serviceProvider) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync<TIdentity>(CancellationToken cancellationToken = default(CancellationToken)) where TIdentity : class
        {
            ApplyAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExceptionLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserCredentialConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new DeliverySettingsConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantConfiguration());
            modelBuilder.ApplyConfiguration(new SocietyConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantSocietyConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerProfileConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTemplateConfiguration());

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            {
                property.SetColumnType("timestamp without time zone");
            }
        }
        private void ApplyAuditInfo()
        {
            var userId = 1; // Replace with actual user ID retrieval logic

            foreach (var entry in ChangeTracker.Entries<BaseEntity<int>>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.AddedDate = DateTime.Now;
                    entry.Entity.AddedByUserId = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                    entry.Entity.UpdatedByUserId = userId;
                }
            }
        }

        public IDbConnection Connection => Database.GetDbConnection();
        public DbSet<ExceptionLog> ExceptionLogs => Set<ExceptionLog>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserCredential> UserCredentials => Set<UserCredential>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();        
        public DbSet<DeliverySettings> DeliverySettings => Set<DeliverySettings>();
        public DbSet<Merchant> Merchants => Set<Merchant>();
        public DbSet<Society> Societies => Set<Society>();
        public DbSet<MerchantSociety> MerchantSocieties => Set<MerchantSociety>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
        public DbSet<OrderStatusHistory> OrderStatusHistories => Set<OrderStatusHistory>();
        public DbSet<Catalog> Catalogs => Set<Catalog>();
        public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();
        public DbSet<OrderTemplate> OrderTemplates => Set<OrderTemplate>();


    }
}
