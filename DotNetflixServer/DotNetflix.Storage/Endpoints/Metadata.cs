using System.Text.Json;
using Contracts.Shared;
using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using Microsoft.AspNetCore.Mvc;
using static Configuration.Shared.Constants.HttpRequestHeaderNames;
using static Microsoft.AspNetCore.Http.Results;

namespace DotNetflix.Storage.Endpoints;

public static class Metadata
{
    public static void MapMetadataEndpoints(this WebApplication app)
    {
        app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/metadata"), application =>
        {
            application.Use((context, next) =>
            {
                if (context.Request.Method != HttpMethods.Delete &&
                    !context.Request.Headers.TryGetValue(MetaDataTypeHeaderName, out _))
                {
                    context.Response.StatusCode = 400;
                    context.Response.WriteAsync($"{MetaDataTypeHeaderName} header is required");
                    return context.Response.StartAsync();
                }

                return next(context);
            });
        });

        app.MapGet("api/metadata/{movieId:int}",
            async (int movieId, HttpContext context, IServiceProvider serviceProvider) =>
            {
                var metaDataType = context.Request.Headers[MetaDataTypeHeaderName];

                return metaDataType.ToString() switch
                {
                    "trailers" => await GetMetaDataAsync(
                        movieId, serviceProvider.GetRequiredService<IPermanentStorageMetadata<MovieTrailerMetadata>>(),
                        x => new TrailerMetaDataDto(x.Id, x.Name, x.FileName, x.Date, x.Language, x.Resolution)),
                    "posters" => await GetMetaDataAsync(
                        movieId, serviceProvider.GetRequiredService<IPermanentStorageMetadata<MoviePosterMetadata>>(),
                        x => new PosterMetaDataDto(x.Id, x.Name, x.FileName, x.Resolution)),
                    _ => BadRequest($"Wrong {MetaDataTypeHeaderName} header value")
                };
            });

        app.MapPost("api/metadata/{movieId:int}", async (int movieId, [FromBody] object metaDataJson,
            HttpContext context, ITemporaryStorageMetadataService storage) =>
        {
            var metaDataType = context.Request.Headers[MetaDataTypeHeaderName];

            return metaDataType.ToString() switch
            {
                "trailers" => await AddMetaDataAsync<MovieTrailerMetadata, TrailerMetaDataDto>(metaDataJson.ToString(),
                    "trailers", movieId, storage,
                    (x, id) => new MovieTrailerMetadata
                    {
                        Id = id,
                        Name = x.Name,
                        FileName = $"{id}{x.FileName}",
                        Date = x.Date,
                        Language = x.Language,
                        Resolution = x.Resolution,
                        MovieId = movieId
                    }),
                "posters" => await AddMetaDataAsync<MoviePosterMetadata, PosterMetaDataDto>(metaDataJson.ToString(),
                    "posters", movieId, storage,
                    (x, id) => new MoviePosterMetadata
                    {
                        Id = id,
                        Name = x.Name,
                        FileName = $"{id}{x.FileName}",
                        Resolution = x.Resolution,
                        MovieId = movieId
                    }),
                _ => BadRequest($"Wrong {MetaDataTypeHeaderName} header value")
            };
        });

        app.MapPut("api/metadata/{movieId:int}", async (int movieId, [FromQuery] Guid id,
            [FromBody] object metaDataJson, HttpContext context, IServiceProvider serviceProvider) =>
        {
            var metaDataType = context.Request.Headers[MetaDataTypeHeaderName];

            return metaDataType.ToString() switch
            {
                "trailers" => await UpdateMetaDataAsync<MovieTrailerMetadata, TrailerMetaDataDto>(
                    metaDataJson.ToString(),
                    serviceProvider.GetRequiredService<IPermanentStorageMetadata<MovieTrailerMetadata>>(),
                    x => new MovieTrailerMetadata
                    {
                        Id = id,
                        Name = x.Name,
                        FileName = x.FileName,
                        Date = x.Date,
                        Language = x.Language,
                        Resolution = x.Resolution,
                        MovieId = movieId
                    }),
                "posters" => await UpdateMetaDataAsync<MoviePosterMetadata, PosterMetaDataDto>(metaDataJson.ToString(),
                    serviceProvider.GetRequiredService<IPermanentStorageMetadata<MoviePosterMetadata>>(),
                    x => new MoviePosterMetadata
                    {
                        Id = id,
                        Name = x.Name,
                        FileName = x.FileName,
                        Resolution = x.Resolution,
                        MovieId = movieId
                    }),
                _ => BadRequest($"Wrong {MetaDataTypeHeaderName} header value")
            };
        });

        app.MapDelete("api/metadata/{movieId:int}", async (int movieId,
            IPermanentStorageMetadata<MovieTrailerMetadata> trailerMetaDataStorage,
            IPermanentStorageMetadata<MoviePosterMetadata> posterMetaDataStorage) =>
        {
            await trailerMetaDataStorage.DeleteByMovieIdAsync(movieId);
            await posterMetaDataStorage.DeleteByMovieIdAsync(movieId);

            return Ok();
        });

        app.MapDelete("api/metadata/{id:guid}", async (Guid id,
            IPermanentStorageMetadata<MovieTrailerMetadata> trailerMetaDataStorage,
            IPermanentStorageMetadata<MoviePosterMetadata> posterMetaDataStorage) =>
        {
            await trailerMetaDataStorage.DeleteAsync(id);
            await posterMetaDataStorage.DeleteAsync(id);

            return Ok();
        });
    }

    private static async Task<IResult> AddMetaDataAsync<TEntity, TDto>(string? metaDataJson, string metaDataType,
        int movieId, ITemporaryStorageMetadataService storage, Func<TDto, Guid, TEntity> transformer)
    {
        var deserialized = JsonSerializer.Deserialize<IEnumerable<TDto>>(metaDataJson ?? "[]");
        
        if (deserialized is null || !deserialized.Any())
        {
            return BadRequest("Wrong body format");
        }

        var ids = new List<Guid>();
        var entities = deserialized.Select(x => 
        {
            var id = Guid.NewGuid();
            ids.Add(id);
            return transformer(x, id);
        });
        var entitiesJson = JsonSerializer.Serialize(entities);
        var key = $"{movieId}-{metaDataType}";
        var counterKey = $"{movieId}-counter";
        await storage.SetStringAsync(entitiesJson, key, 60);
        await storage.SetStringAsync("1", counterKey, 60);

        return Ok(ids);
    }

    private static async Task<IResult> GetMetaDataAsync<TEntity, TDto>(int movieId,
        IPermanentStorageMetadata<TEntity> storage, Func<TEntity, TDto> transformer)
        where TEntity : IMongoDbEntity
    {
        var metaData = await storage.GetByMovieIdAsync(movieId);

        return Ok(metaData.Select(transformer));
    }

    private static async Task<IResult> UpdateMetaDataAsync<TEntity, TDto>(string? metaDataJson,
        IPermanentStorageMetadata<TEntity> storage, Func<TDto, TEntity> transformer)
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