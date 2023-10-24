using System.Reflection;
using DotNetflix.Abstractions.Cqrs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Abstractions;

public static class ServicesRegistration
{
    private static readonly Type QueryType = typeof(IQuery<>);
    private static readonly Type CommandType = typeof(ICommand<>);
    private static readonly Type PipelineBehaviorType = typeof(IPipelineBehavior<,>);
    private static readonly Type ResultType = typeof(Result<,>);

    public static IServiceCollection RegisterBehaviorReturningResult(this IServiceCollection serviceCollection, Assembly assembly,
        Type? constraintType, Type behaviorType)
    {
        var generics = assembly
            .GetTypes()
            .Where(x => constraintType is null || x.IsAssignableTo(constraintType))
            .Where(x => x.GetInterfaces().Where(i => i.IsGenericType).Any(i =>
            {
                var genericTypeDefinition = i.GetGenericTypeDefinition();
                return (genericTypeDefinition == QueryType || genericTypeDefinition == CommandType)
                       && i.GetGenericArguments()[0].GetGenericTypeDefinition() == ResultType;
            }))
            .Select(x =>
            {
                var genericTypeForIpb = x.GetInterfaces()[0].GetGenericArguments()[0];
                var genericTypeForBehaviorType = genericTypeForIpb.GetGenericArguments()[0];

                return new
                {
                    RequestType = x,
                    GenericForIpb = genericTypeForIpb,
                    GenericForBehaviorType = genericTypeForBehaviorType
                };
            });

        foreach (var generic in generics)
        {
            serviceCollection.AddTransient(
                PipelineBehaviorType.MakeGenericType(generic.RequestType, generic.GenericForIpb),
                behaviorType.MakeGenericType(generic.RequestType, generic.GenericForBehaviorType));
        }

        return serviceCollection;
    }
}