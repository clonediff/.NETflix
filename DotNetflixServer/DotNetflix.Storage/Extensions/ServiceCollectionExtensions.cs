using Configuration.Shared.RabbitMq;
using DotNetflix.Storage.Consumers;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DotNetflix.Storage.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection serviceCollection,
		RabbitMqConfig rabbitMqConfig)
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

	public static void AddMongoDb(this IServiceCollection serviceCollection, IConfiguration configuration)
	{
		var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
		var database = client.GetDatabase("main");
		
		serviceCollection.AddSingleton(database);
	}
}