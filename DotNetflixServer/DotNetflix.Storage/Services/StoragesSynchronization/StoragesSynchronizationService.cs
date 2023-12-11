using DotNetflix.Storage.Services.PermanentStorageMetadata;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.S3;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using Newtonsoft.Json;

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

    public async Task<bool> SynchronizeStorages(string metadataKey, string transactionKey)
    {
        var metadataValue = await _temporaryMetadataStorage.GetStringAsync(metadataKey);
        
        var type = metadataKey.Contains("poster") ? typeof(MoviePosterMetadata) : typeof(MovieTrailerMetadata);
        dynamic metadata = JsonConvert.DeserializeObject(metadataValue!, type)!;
        dynamic storage = type == typeof(MoviePosterMetadata) ? _posterMetadataStorage : _trailerMetadataStorage;
        
        var res = await SendFilmAndMetadata(metadata, storage);

        if (res)
            await _temporaryMetadataStorage.SetStringAsync("3", transactionKey, 1000);

        return res;
    }

    private async Task<bool> SendFilmAndMetadata<TEntity>(TEntity metadata,
        IPermanentStorageMetadata<TEntity> storage) where TEntity : IMongoDbEntity
    {
        var permanentStorageName = $"film-{metadata.MovieId}";
        var poster = await _s3StorageService.GetFileFromBucketAsync(metadata.FileName,
            _temporaryBucketId);
        
        var mongoMetadata = (await storage
            .GetByMovieIdAsync(metadata.MovieId)).FirstOrDefault(m => m.Id == metadata.Id);
        
        if(mongoMetadata == null) 
            await storage.InsertAsync(metadata);

        var isBucketExists = await _s3StorageService.BucketExistAsync(permanentStorageName);
        if(!isBucketExists)
            await _s3StorageService.CreateBucketAsync(permanentStorageName);
        
        await _s3StorageService.PutFileInBucketAsync(poster!, metadata.FileName,
            permanentStorageName);
        
        return await _s3StorageService.GetFileFromBucketAsync(metadata.FileName, 
            permanentStorageName) != null;
    }
}