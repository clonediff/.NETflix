using Configuration.Shared.RabbitMq;
using DotNetflix.Storage.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetflix.Storage.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection serviceCollection, RabbitMqConfig rabbitMqConfig)
    {
        serviceCollection.AddMassTransit(config =>
        {
            config.AddConsumer<FileMessageConsumer>();
            
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(rabbitMqConfig.FullHostname);
                cfg.ConfigureEndpoints(ctx);
            });
        });
        
        return serviceCollection;
    }
}