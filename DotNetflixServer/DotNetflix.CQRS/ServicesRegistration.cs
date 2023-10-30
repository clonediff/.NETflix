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

    public static IServiceCollection RegisterBehaviorsReturningResult(this IServiceCollection serviceCollection, Assembly assembly)
    {
        var types = assembly.GetTypes();
        
        var behaviorTypes = types
            .Where(x => x
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == PipelineBehaviorType))
            .Select(x => new
            {
                BehaviorType = x,
                BehaviorTypeConstraints = x
                    .GetGenericArguments()[0]
                    .GetGenericParameterConstraints()
            })
            .ToList();

        var behaviors = types
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
                var ipbImpls = behaviorTypes
                    .Where(b => !b.BehaviorTypeConstraints.Any() || b.BehaviorTypeConstraints.Any(x.IsAssignableTo))
                    .Select(b => b.BehaviorType.MakeGenericType(x, successTypeForIpbImpl));

                return new
                {
                    Ipb = ipb,
                    IpbImpls = ipbImpls,
                };
            })
            .Where(x => x.IpbImpls.Any());

        foreach (var behavior in behaviors)
        {
            serviceCollection.TryAddEnumerable(behavior.IpbImpls
                .Select(x => new ServiceDescriptor(behavior.Ipb, x, ServiceLifetime.Transient)));
        }

        return serviceCollection;
    }
}