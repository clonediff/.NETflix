using Configuration.Shared.RabbitMq;
using DotNetflix.S3.Extensions;
using DotNetflix.S3.Services;
using Minio;

var builder = WebApplication.CreateBuilder(args);

var rabbitMqConfig = builder.Configuration.GetSection(RabbitMqConfig.SectionName).Get<RabbitMqConfig>()!;

builder.Services.AddMasstransitRabbitMq(rabbitMqConfig);

builder.Services.AddMinio(configuration =>
{
    configuration.WithSSL(false);
    configuration.WithTimeout(int.Parse(builder.Configuration["MinioS3:Timeout"]!));
    configuration.WithEndpoint(builder.Configuration["MinioS3:Endpoint"]);
    configuration.WithCredentials(
        builder.Configuration["MinioS3:AccessKey"]!,
        builder.Configuration["MinioS3:SecretKey"]!);
});

builder.Services.AddSingleton<IS3StorageService, MinioS3StorageService>();

var app = builder.Build();

app.MapGet("api/files/{bucketName}/{fileName}", async (string bucketName, string fileName, IS3StorageService storageService) =>
{
    var stream = await storageService.GetFileFromBucketAsync(fileName, bucketName);

    return stream is not null
        ? Results.Stream(stream)
        : Results.NotFound();
});

app.Run();