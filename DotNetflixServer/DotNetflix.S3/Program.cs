using DotNetflix.S3.Services;
using Minio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMinio(configuration =>
{
    configuration.WithTimeout(int.Parse(builder.Configuration["MinioS3:Timeout"]!));
    configuration.WithEndpoint(builder.Configuration["MinioS3:Endpoint"]);
    configuration.WithCredentials(
        builder.Configuration["MinioS3:AccessKey"]!,
        builder.Configuration["MinioS3:SecretKey"]!);
});

builder.Services.AddSingleton<IS3StorageService, MinioS3StorageService>();

var app = builder.Build();
app.Run();