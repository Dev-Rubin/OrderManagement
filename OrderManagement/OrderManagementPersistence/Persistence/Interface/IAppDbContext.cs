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
    }
}
