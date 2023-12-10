using DotNetflix.Storage.Services.S3;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.Results;

namespace DotNetflix.Storage.Endpoints;

public static class Files
{
    public static void MapFileEndpoints(this WebApplication app, IConfiguration configuration)
    {
        var temporaryBucketName = configuration["TemporaryBucketName"]!;
        
        app.MapGet("api/files/{bucketName}/{fileName}", async (string bucketName, string fileName, IS3StorageService storageService) =>
        {
            var stream = await storageService.GetFileFromBucketAsync(fileName, bucketName);

            return stream is not null
                ? Stream(stream)
                : NotFound();
        });

        app.MapPost("api/files/{bucketName}/{fileName}", async (string bucketName, string fileName, [FromForm] IFormFile file, IS3StorageService storageService, ITemporaryStorageMetadataService temporaryStorage) =>
        {            
            var bucketExists = await storageService.BucketExistAsync(temporaryBucketName);

            if (!bucketExists)
            {
                await storageService.CreateBucketAsync(temporaryBucketName);
            }
            
            await storageService.PutFileInBucketAsync(file.OpenReadStream(), fileName, temporaryBucketName);

            var counterKey = $"{bucketName}-counter";
            await temporaryStorage.SetStringAsync("2", counterKey, 60);

            return Ok();
        });

        app.MapDelete("api/files/{bucketName}/{fileName}", async (string bucketName, string fileName, IS3StorageService storageService) =>
        {
            await storageService.RemoveFileFromBucketAsync(fileName, bucketName);

            return Ok();
        });

        app.MapDelete("api/files/{bucketName}", async (string bucketName, IS3StorageService storageService) =>
        {
            await storageService.RemoveBucketAsync(bucketName);

            return Ok();
        });
    }
}