using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Behaviors;
using OrderManagement.Application.Validators.Auth;
using System.Reflection;

namespace OrderManagement.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterHandler(services, configuration);
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
        public static void RegisterHandler(this IServiceCollection services, IConfiguration configuration)
        {
            var requestHandlerTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();

            foreach (var handlerType in requestHandlerTypes)
            {
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(handlerType.Assembly));
            }
        }
    }
}
