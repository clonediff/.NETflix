using System.Text.Json;
using System.Text.RegularExpressions;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using DotNetflix.Storage.Services.S3;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;

namespace DotNetflix.Storage.Services.TemporaryStoragesCleaner;

public class TemporaryStoragesCleaner : ITemporaryStoragesCleaner
{
    private readonly ITemporaryStorageMetadataService _temporaryMetadataStorage;
    private readonly IS3StorageService _s3StorageService;
    private readonly string _temporaryBucketId;

    public TemporaryStoragesCleaner(ITemporaryStorageMetadataService temporaryMetadataStorage,
        IS3StorageService s3StorageService,
        IConfiguration configuration)
    {
        _temporaryMetadataStorage = temporaryMetadataStorage;
        _s3StorageService = s3StorageService;
        _temporaryBucketId = configuration.GetSection("TemporaryBucketName").Get<string>()!;
    }

    public async Task<bool> ClearStorages(string movieId, string transactionKey)
    {
        var posters = await _temporaryMetadataStorage.GetStringAsync($"{movieId}-posters");
        var trailers = await _temporaryMetadataStorage.GetStringAsync($"{movieId}-trailers");
        var deserializedPosters = JsonSerializer.Deserialize<IEnumerable<MoviePosterMetadata>>(posters ?? "[]");
        var deserializedTrailers = JsonSerializer.Deserialize<IEnumerable<MovieTrailerMetadata>>(trailers ?? "[]");
        
        foreach (var p in deserializedPosters ?? Enumerable.Empty<MoviePosterMetadata>())
        {
            await _s3StorageService.RemoveFileFromBucketAsync(p.FileName, _temporaryBucketId);   
        }

        foreach (var t in deserializedTrailers ?? Enumerable.Empty<MovieTrailerMetadata>())
        {
            await _s3StorageService.RemoveFileFromBucketAsync(t.FileName, _temporaryBucketId);   
        }

        await _temporaryMetadataStorage.RemoveAsync($"{movieId}-posters");
        await _temporaryMetadataStorage.RemoveAsync($"{movieId}-trailers");
        await _temporaryMetadataStorage.RemoveAsync(transactionKey);
        
        return true;
    }
}