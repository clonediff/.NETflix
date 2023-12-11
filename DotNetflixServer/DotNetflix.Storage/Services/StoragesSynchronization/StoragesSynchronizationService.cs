using System.Text.Json;
using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.S3;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;

namespace DotNetflix.Storage.Services.StoragesSynchronization;

public class StoragesSynchronizationService : IStoragesSynchronizationService
{
    private readonly ITemporaryStorageMetadataService _temporaryMetadataStorage;
    private readonly IS3StorageService _s3StorageService;
    private readonly IPermanentStorageMetadata<MoviePosterMetadata> _posterMetadataStorage;
    private readonly IPermanentStorageMetadata<MovieTrailerMetadata> _trailerMetadataStorage;
    
    private readonly string _temporaryBucketId;

    public StoragesSynchronizationService(ITemporaryStorageMetadataService temporaryMetadataStorage,
        IS3StorageService s3StorageService, 
        IPermanentStorageMetadata<MovieTrailerMetadata> trailerMetadataStorage,
        IPermanentStorageMetadata<MoviePosterMetadata> posterMetadataStorage,
        IConfiguration configuration)
    {
        _temporaryMetadataStorage = temporaryMetadataStorage;
        _s3StorageService = s3StorageService;
        _trailerMetadataStorage = trailerMetadataStorage;
        _posterMetadataStorage = posterMetadataStorage;
        _temporaryBucketId = configuration.GetSection("TemporaryBucketName").Get<string>()!;
    }

    public async Task<bool> SynchronizeStorages(string movieId, string transactionKey)
    {
        var posters = await _temporaryMetadataStorage.GetStringAsync($"{movieId}-posters");
        var trailers = await _temporaryMetadataStorage.GetStringAsync($"{movieId}-trailers");
        var deserializedPosters = JsonSerializer.Deserialize<IEnumerable<MoviePosterMetadata>>(posters ?? "[]");
        var deserializedTrailers = JsonSerializer.Deserialize<IEnumerable<MovieTrailerMetadata>>(trailers ?? "[]");
        var resPosters = true;
        var resTrailers = true;

        foreach (var p in deserializedPosters ?? Enumerable.Empty<MoviePosterMetadata>())
        {
            if (!await SendFilmAndMetadata(p, _posterMetadataStorage))
            {
                resPosters = false;
            }
        }

        foreach (var t in deserializedTrailers ?? Enumerable.Empty<MovieTrailerMetadata>())
        {
            if (!await SendFilmAndMetadata(t, _trailerMetadataStorage))
            {
                resTrailers = false;
            }
        }

        if (resPosters && resTrailers)
            await _temporaryMetadataStorage.SetStringAsync("3", transactionKey, 1000);

        return resPosters && resTrailers;
    }

    private async Task<bool> SendFilmAndMetadata<TEntity>(TEntity metadata,
        IPermanentStorageMetadata<TEntity> storage) where TEntity : IMongoDbEntity
    {
        var permanentStorageName = $"film-{metadata.MovieId}";
        var file = await _s3StorageService.GetFileFromBucketAsync(metadata.FileName,
            _temporaryBucketId);
        
        var mongoMetadata = (await storage
            .GetByMovieIdAsync(metadata.MovieId)).FirstOrDefault(m => m.Id == metadata.Id);
        
        if(mongoMetadata == null) 
        {
            await storage.InsertAsync(metadata);
        }

        var isBucketExists = await _s3StorageService.BucketExistAsync(permanentStorageName);
        if(!isBucketExists)
            await _s3StorageService.CreateBucketAsync(permanentStorageName);
        
        await _s3StorageService.PutFileInBucketAsync(file!, metadata.FileName,
            permanentStorageName);
        
        return await _s3StorageService.GetFileFromBucketAsync(metadata.FileName, 
            permanentStorageName) != null;
    }
}