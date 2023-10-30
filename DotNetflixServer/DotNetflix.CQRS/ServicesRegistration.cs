using System.Reflection;
using DotNetflix.CQRS.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DotNetflix.CQRS;

public static class ServicesRegistration
{
    private static readonly Type QueryType = typeof(IQuery<>);
    private static readonly Type CommandType = typeof(ICommand<>);
    private static readonly Type PipelineBehaviorType = typeof(IPipelineBehavior<,>);
    private static readonly Type ResultType = typeof(Result<,>);

    public static IServiceCollection RegisterBehaviorReturningResult(this IServiceCollection serviceCollection, Assembly assembly)
    {
        var types = assembly.GetTypes();
        
        var behaviors = types
            .Where(x => x
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == PipelineBehaviorType))
            .Select(x => new
            {
                Behavior = x,
                BehaviorConstraints = x
                    .GetGenericArguments()[0]
                    .GetGenericParameterConstraints()
            })
            .ToList();
        
        var generics = types
            .Where(x => x.GetInterfaces().Where(i => i.IsGenericType).Any(i =>
            {
                var genericTypeDefinition = i.GetGenericTypeDefinition();
                var genericArguments = i.GetGenericArguments();
                return (genericTypeDefinition == QueryType || genericTypeDefinition == CommandType)
                       && genericArguments[0].IsGenericType 
                       && genericArguments[0].GetGenericTypeDefinition() == ResultType;
            }))
            .Select(x =>
            {
                var resultTypeForIpb = x.GetInterfaces()[0].GetGenericArguments()[0];
                var successTypeForIpbImpl = resultTypeForIpb.GetGenericArguments()[0];

                var ipb = PipelineBehaviorType.MakeGenericType(x, resultTypeForIpb);
                var ipbImpls = behaviors
                    .Where(b => b.BehaviorConstraints.Length == 0 || b.BehaviorConstraints
                        .Any(x.IsAssignableTo))
                    .Select(b => b.Behavior.MakeGenericType(x, successTypeForIpbImpl))
                    .ToList();
                
                return new
                {
                    Ipb = ipb,
                    IpbImpls = ipbImpls,
                };
            })
            .Where(x => x.IpbImpls.Any())
            .ToList();

        foreach (var generic in generics)
        {
            serviceCollection.TryAddEnumerable(generic.IpbImpls
                .Select(x => new ServiceDescriptor(generic.Ipb, x, ServiceLifetime.Transient)));
        }

        return serviceCollection;
    }
}