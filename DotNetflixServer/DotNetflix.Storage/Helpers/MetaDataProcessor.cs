using System.Text.Json;
using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using static Microsoft.AspNetCore.Http.Results;

namespace DotNetflix.Storage.Helpers;

internal static class MetaDataProcessor
{
    internal static async Task<IResult> AddMetaDataAsync<TEntity, TDto>(string? metaDataJson, string metaDataType, int movieId, ITemporaryStorageMetadataService storage, Func<TDto, Guid, TEntity> transformer)
    {
        var deserialized = JsonSerializer.Deserialize<IEnumerable<TDto>>(metaDataJson ?? "[]");
        
        if (deserialized is null || !deserialized.Any())
        {
            return BadRequest("Wrong body format");
        }

        var entities = deserialized.Select(x => transformer(x, Guid.NewGuid()));
        var entitiesJson = JsonSerializer.Serialize(entities);
        var key = $"{movieId}-{metaDataType}";
        var counterKey = $"{movieId}-counter";
        await storage.SetStringAsync(entitiesJson, key, 60);
        await storage.SetStringAsync("1", counterKey, 60);
        
        return Ok();
    }

    internal static async Task<IResult> GetMetaDataAsync<TEntity, TDto>(int movieId, IPermanentStorageMetadata<TEntity> storage, Func<TEntity, TDto> transformer) 
        where TEntity : IMongoDbEntity
    {
        var metaData = await storage.GetByMovieIdAsync(movieId);

        return Ok(metaData.Select(transformer));
    }

    internal static async Task<IResult> UpdateMetaDataAsync<TEntity, TDto>(string? metaDataJson, IPermanentStorageMetadata<TEntity> storage, Func<TDto, TEntity> transformer)
        where TEntity : IMongoDbEntity
    {
        var deserialized = JsonSerializer.Deserialize<TDto>(metaDataJson ?? "{}");

        if (deserialized is null)
        {
            return BadRequest("Wrong body format");
        }

        var entity = transformer(deserialized);
        await storage.UpdateAsync(entity);

        return Ok();
    }
}