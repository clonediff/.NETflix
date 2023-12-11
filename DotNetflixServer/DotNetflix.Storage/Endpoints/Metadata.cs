using Contracts.Shared;
using DotNetflix.Storage.Mapping;
using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using Microsoft.AspNetCore.Mvc;
using static Configuration.Shared.Constants.HttpRequestHeaderNames;
using static Microsoft.AspNetCore.Http.Results;
using static DotNetflix.Storage.Helpers.MetaDataProcessor;

namespace DotNetflix.Storage.Endpoints;

public static class Metadata
{
    public static void MapMetadataEndpoints(this WebApplication app)
    {
        app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/metadata"), application =>
        {
            application.Use((context, next) =>
            {
                if (context.Request.Method != HttpMethods.Delete && !context.Request.Headers.TryGetValue(MetaDataTypeHeaderName, out _))
                {
                    context.Response.StatusCode = 400;
                    context.Response.WriteAsync($"{MetaDataTypeHeaderName} header is required");
                    return context.Response.StartAsync();
                }

                return next(context);
            });
        });
        
        app.MapGet("api/metadata/{movieId:int}", async (int movieId, HttpContext context, IServiceProvider serviceProvider) =>
        {
            var metaDataType = context.Request.Headers[MetaDataTypeHeaderName];

            return metaDataType.ToString() switch
            {
                "trailers" => await GetMetaDataAsync(
                    movieId, serviceProvider.GetRequiredService<IPermanentStorageMetadata<MovieTrailerMetadata>>(), 
                    x => x.ToTrailerMetaDataDto()),
                "posters" => await GetMetaDataAsync(
                    movieId, serviceProvider.GetRequiredService<IPermanentStorageMetadata<MoviePosterMetadata>>(), 
                    x => x.ToPosterMetaDataDto()),
                _ => BadRequest($"Wrong {MetaDataTypeHeaderName} header value")
            };
        });

        app.MapPost("api/metadata/{movieId:int}", async (int movieId, [FromBody] object metaDataJson, HttpContext context, ITemporaryStorageMetadataService storage, IServiceProvider sp) =>
        {
            var metaDataType = context.Request.Headers[MetaDataTypeHeaderName];

            return metaDataType.ToString() switch
            {
                "trailers" => await AddMetaDataAsync<MovieTrailerMetadata, TrailerMetaDataDto>(metaDataJson.ToString(), "trailers", movieId, storage,
                    (x, id) => x.ToMovieTrailerMetaData(id, movieId)),
                "posters" => await AddMetaDataAsync<MoviePosterMetadata, PosterMetaDataDto>(metaDataJson.ToString(), "posters", movieId, storage,
                    (x, id) => x.ToMoviePosterMetaData(id, movieId)),
                _ => BadRequest($"Wrong {MetaDataTypeHeaderName} header value")
            };
        });

        app.MapPut("api/metadata/{movieId:int}", async (int movieId, [FromQuery] Guid id, [FromBody] object metaDataJson, HttpContext context, IServiceProvider serviceProvider) =>
        {
            var metaDataType = context.Request.Headers[MetaDataTypeHeaderName];

            return metaDataType.ToString() switch
            {
                "trailers" => await UpdateMetaDataAsync<MovieTrailerMetadata, TrailerMetaDataDto>(metaDataJson.ToString(), 
                    serviceProvider.GetRequiredService<IPermanentStorageMetadata<MovieTrailerMetadata>>(),
                    x => x.ToMovieTrailerMetaData(id, movieId)),
                "posters" => await UpdateMetaDataAsync<MoviePosterMetadata, PosterMetaDataDto>(metaDataJson.ToString(),
                    serviceProvider.GetRequiredService<IPermanentStorageMetadata<MoviePosterMetadata>>(),
                    x => x.ToMoviePosterMetaData(id, movieId)),
                _ => BadRequest($"Wrong {MetaDataTypeHeaderName} header value")
            };
        });

        app.MapDelete("api/metadata/{movieId:int}", async (int movieId, IPermanentStorageMetadata<MovieTrailerMetadata> trailerMetaDataStorage, IPermanentStorageMetadata<MoviePosterMetadata> posterMetaDataStorage) =>
        {
            await trailerMetaDataStorage.DeleteByMovieIdAsync(movieId);
            await posterMetaDataStorage.DeleteByMovieIdAsync(movieId);

            return Ok();
        });

        app.MapDelete("api/metadata/{id:guid}", async (Guid id, IPermanentStorageMetadata<MovieTrailerMetadata> trailerMetaDataStorage, IPermanentStorageMetadata<MoviePosterMetadata> posterMetaDataStorage) =>
        {
            await trailerMetaDataStorage.DeleteAsync(id);
            await posterMetaDataStorage.DeleteAsync(id);

            return Ok();
        });
    }
}