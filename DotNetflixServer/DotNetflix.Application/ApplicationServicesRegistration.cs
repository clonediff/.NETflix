using System.Reflection;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Behaviors;
using DotNetflix.Application.Features.Authentication.Commands.Login;
using DotNetflix.Application.Features.Authentication.Commands.Register;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Application;

public static class ApplicationServicesRegistration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly);
        });

        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(CardValidationBehavior<,>), typeof(IHasCardValidation));
        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(TokenValidationBehavior<,>), typeof(IHasTokenValidation));
        serviceCollection.RegisterBehaviorReturningResult(Assembly, typeof(ValidationBehavior<,>), typeof(IRequest<Result<string, string>>)); 
        
        serviceCollection.AddValidatorsFromAssembly(Assembly);

        return serviceCollection;
    }
}