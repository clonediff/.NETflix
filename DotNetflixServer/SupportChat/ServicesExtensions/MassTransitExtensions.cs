using MassTransit;
using Services.Shared.RabbitMq;
using SupportChat.Consumers;

namespace SupportChat.ServicesExtensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection services, RabbitMqConfig rabbitMqConfig)
    {
        services.AddMassTransit(config =>
        {
            config.AddConsumer<SupportChatMessageConsumer>();
            
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(rabbitMqConfig.FullHostname);
                cfg.ConfigureEndpoints(ctx);
            });
        });
        return services;
    }
}
