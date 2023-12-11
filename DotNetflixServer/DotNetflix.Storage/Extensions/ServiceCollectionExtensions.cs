using Configuration.Shared.RabbitMq;
using DotNetflix.Storage.BackgroundServices;
using DotNetflix.Storage.Consumers;
using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.StoragesSynchronization;
using DotNetflix.Storage.Services.TemporaryStoragesCleaner;
using MassTransit;
using MongoDB.Driver;
using StackExchange.Redis;

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
		
		serviceCollection.AddSingleton<IPermanentStorageMetadata<MovieTrailerMetadata>>(
			new MongoDbStorage<MovieTrailerMetadata>(
				database.GetCollection<MovieTrailerMetadata>(nameof(MovieTrailerMetadata))));

		serviceCollection.AddSingleton<IPermanentStorageMetadata<MoviePosterMetadata>>(
			new MongoDbStorage<MoviePosterMetadata>(
				database.GetCollection<MoviePosterMetadata>(nameof(MoviePosterMetadata))));
	}

	public static IServiceCollection AddHostedServices(this IServiceCollection services)
	{
		return services
			.AddHostedService<StoragesDataSynchronizationWorker>()
			.AddHostedService<CleanTemporaryStoragesWorker>();
	}

	public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddStackExchangeRedisCache(options =>
			options.Configuration = configuration.GetConnectionString("Redis"));
		services.AddSingleton<IConnectionMultiplexer>(_ => 
			ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
		return services;
	}

	public static IServiceCollection AddStoragesInteractionServices(this IServiceCollection services)
	{
		return services
			.AddSingleton<ITemporaryStoragesCleaner, TemporaryStoragesCleaner>()
			.AddSingleton<IStoragesSynchronizationService, StoragesSynchronizationService>();
	}
}