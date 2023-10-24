using System.Reflection;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Application;

public static class ApplicationServicesRegistration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(IHasCardValidation), typeof(CardValidationBehavior<,>));
        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(IHasCodeValidation), typeof(CodeValidationBehavior<,>));
        
        return serviceCollection;
    }
}