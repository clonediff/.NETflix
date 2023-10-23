using System.Reflection;
using DotNetflix.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(CardValidationBehavior<,>));
        });

        return serviceCollection;
    }
}