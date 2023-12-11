using System.Text.RegularExpressions;
using DotNetflix.Storage.Services.S3;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using Newtonsoft.Json;

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

    public async Task<bool> ClearStorages(string metadataKey, string transactionKey)
    {
        var metadataValue = await _temporaryMetadataStorage.GetStringAsync(metadataKey);
        
        var metadata = JsonConvert.DeserializeObject<dynamic>(metadataValue!);
        string filename = metadata!.FileName;
        
        await _temporaryMetadataStorage.RemoveAsync(metadataKey);
        await _temporaryMetadataStorage.RemoveAsync(transactionKey);

        await _s3StorageService.RemoveFileFromBucketAsync(filename, _temporaryBucketId);
        
        return true;
    }
}