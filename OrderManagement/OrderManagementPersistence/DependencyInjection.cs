using OrderManagement.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using EMS.Infrastructure.Persistence.Service;

namespace OrderManagement.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                ),
                ServiceLifetime.Scoped
            );
            services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());

            services.AddScoped<IAppReadDbConnection, AppReadDbConnection>();
            services.AddScoped<IAppWriteDbConnection, AppWriteDbConnection>();

            //services.AddScoped<IUserContext, UserContext>();

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IQueries, Queries>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
