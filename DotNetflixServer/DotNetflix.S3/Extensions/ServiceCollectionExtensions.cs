using Configuration.Shared.RabbitMq;
using DotNetflix.S3.Consumers;
using MassTransit;

namespace DotNetflix.S3.Extensions;

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