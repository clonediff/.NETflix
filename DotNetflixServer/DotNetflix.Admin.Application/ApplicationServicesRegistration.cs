using System.Reflection;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Admin.Application;

public static class ApplicationServicesRegistration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));

        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(UserIdValidationBehavior<,>), typeof(IHasUserIdValidation));

        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(ValidationBehavior<,>),
            typeof(IRequest<Result<string, string>>));
        serviceCollection.AddValidatorsFromAssembly(Assembly);
        
        return serviceCollection;
    }
}