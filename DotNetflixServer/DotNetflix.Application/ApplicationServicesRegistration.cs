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
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                .AddBehavior<IPipelineBehavior<LoginCommand, Result<string, IEnumerable<string>>>,
                    ValidationBehavior<LoginCommand, string>>()
                .AddBehavior<IPipelineBehavior<RegistrationCommand, Result<string, IEnumerable<string>>>,
                    ValidationBehavior<RegistrationCommand, string>>();
        });

        serviceCollection.RegisterBehavior(Assembly, typeof(IHasCardValidation), typeof(CardValidationBehavior<,>));
        serviceCollection.AddValidatorsFromAssembly(Assembly);
        return serviceCollection;
    }
}