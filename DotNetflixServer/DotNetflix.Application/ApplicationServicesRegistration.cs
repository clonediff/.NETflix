using System.Reflection;
using DotNetflix.CQRS;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Application;

public static class ApplicationServicesRegistration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));

        serviceCollection.RegisterBehaviorReturningResult(Assembly); 
        
        serviceCollection.AddValidatorsFromAssembly(Assembly);

        return serviceCollection;
    }
}