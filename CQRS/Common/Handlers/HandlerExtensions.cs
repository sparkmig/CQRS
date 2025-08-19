using System.Reflection;
using CQRS.Common.Handlers.Command;
using CQRS.Common.Handlers.Query;

namespace CQRS.Common.Handlers;

public static class HandlerExtensions
{
    public static IServiceCollection AddCqrsHandlers(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<ApplicationDispatcher>();

        // Register all query handlers
        var queryHandlerType = typeof(IQueryHandler<,>);
        foreach (var type in assembly.GetTypes())
        {
            var interfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == queryHandlerType);

            foreach (var @interface in interfaces)
            {
                services.AddTransient(@interface, type);
            }
        }

        // Register all command handlers
        var commandHandlerType = typeof(ICommandHandler<>);
        foreach (var type in assembly.GetTypes())
        {
            var interfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandHandlerType);

            foreach (var @interface in interfaces)
            {
                services.AddTransient(@interface, type);
            }
        }

        return services;
    }
}