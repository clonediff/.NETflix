using System.Reflection;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Admin.Application;

public static class ApplicationServicesRegistration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));

        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(UserIdValidationBehavior<,>), typeof(IHasUserIdValidation));

        return serviceCollection;
    }
}