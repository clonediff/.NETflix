using System.Reflection;
using DotNetflix.CQRS;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Admin.Application;

public static class ApplicationServicesRegistration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));

        serviceCollection.RegisterBehaviorsReturningResult(Assembly);
        
        return serviceCollection;
    }
}