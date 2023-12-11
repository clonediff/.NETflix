using Configuration.Shared.RabbitMq;
using DotNetflix.Storage.Consumers;
using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using MassTransit;
using MongoDB.Driver;

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
}