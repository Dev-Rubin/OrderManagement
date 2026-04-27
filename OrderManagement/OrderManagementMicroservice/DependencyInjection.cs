using AutoMapper;

namespace OrderManagement.Microservice
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<MapperConfiguration>(sp =>
            {
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                return new MapperConfiguration(cfg =>
                {
                    // Recommended: scan specific assembly
                    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());

                    // OR better (if you know profile location):
                    // cfg.AddMaps(typeof(OrderProfile).Assembly);

                }, loggerFactory);
            });

            services.AddScoped<IMapper>(sp =>
            {
                var config = sp.GetRequiredService<MapperConfiguration>();
                return config.CreateMapper(sp.GetService);
            });

            return services;
        }
    }
}
