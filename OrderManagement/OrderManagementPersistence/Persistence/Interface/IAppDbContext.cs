using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrderManagement.Domain.Entities;
using System.Data;

namespace OrderManagement.Infrastructure.Persistence.Interface
{
    public interface IAppDbContext : IDisposable
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

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
