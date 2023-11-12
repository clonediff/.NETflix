using Configuration.Shared.RabbitMq;
using DataAccess;
using Domain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportChat.Consumers;

namespace SupportChat.ServicesExtensions;

public static class ProgramConfigurationExtensions
{
    public static IServiceCollection AddApplicationDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.LogTo(Console.WriteLine);
                options.UseSqlServer(connectionString);
            })
            .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>();

        services.AddScoped<DbContext, ApplicationDBContext>();
        
        return services;
    }
    
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
