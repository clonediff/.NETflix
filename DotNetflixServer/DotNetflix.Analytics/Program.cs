using System.Net;
using ClickHouse.Client.ADO;
using DotNetflix.Analytics.Repositories;
using API.Shared;
using Configuration.Shared.RabbitMq;
using DotNetflix.Analytics.Consumers;
using DotNetflix.Analytics.Extensions;
using DotNetflix.Analytics.GraphQL;

var builder = WebApplication.CreateBuilder(args);

const string httpClientName = "ClickHouseClient";

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(x => x.IncludeExceptionDetails = true)
    .AddQueryType<Queries>();

builder.Services
    .AddHttpClient(httpClientName)
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
    });

builder.Services.AddTransient(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return new ClickHouseConnection(builder.Configuration.GetConnectionString("ClickHouse"), httpClientFactory, httpClientName);
});

var rabbitMqConfig = builder.Configuration.GetSection(RabbitMqConfig.SectionName).Get<RabbitMqConfig>()!;
builder.Services
    .AddMassTransitRabbitMq(rabbitMqConfig, typeof(PersistFilmVisitMessageConsumer))
    .AddTransient<IFilmVisitsRepository, FilmVisitsRepository>();

var app = builder.Build();

await app.CreateFilmVisitsTableAsync();

app.MapGraphQL(new PathString("/graphql"));

app.Run();
