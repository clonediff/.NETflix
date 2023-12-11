using System.Text.RegularExpressions;
using DotNetflix.Storage.Services.StoragesSynchronization;
using DotNetflix.Storage.Services.TemporaryStorageMetadata;
using DotNetflix.Storage.Services.TemporaryStoragesCleaner;
using StackExchange.Redis;

namespace DotNetflix.Storage.BackgroundServices;

public partial class StoragesDataSynchronizationWorker : BackgroundService
{
    private readonly ITemporaryStorageMetadataService _temporaryMetadataStorage;
    private readonly IStoragesSynchronizationService _storagesSynchronizationService;
    private readonly ITemporaryStoragesCleaner _temporaryStoragesCleaner;
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly string? _redisConnectionString;

    private readonly Regex _metadataPattern = MetadataKey();

    public StoragesDataSynchronizationWorker(ITemporaryStorageMetadataService temporaryMetadataStorage,
        IConnectionMultiplexer connectionMultiplexer,
        IConfiguration configuration,
        IStoragesSynchronizationService storagesSynchronizationService,
        ITemporaryStoragesCleaner temporaryStoragesCleaner)
    {
        _temporaryMetadataStorage = temporaryMetadataStorage;
        _connectionMultiplexer = connectionMultiplexer;
        _storagesSynchronizationService = storagesSynchronizationService;
        _temporaryStoragesCleaner = temporaryStoragesCleaner;
        _redisConnectionString = configuration.GetConnectionString("Redis");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var server = _connectionMultiplexer.GetServer(_redisConnectionString!);
            
            await foreach (var key in server.KeysAsync().WithCancellation(stoppingToken))
            {
                if (!_metadataPattern.IsMatch(key.ToString(), 0)) continue;
                var transactionKey = $"{_metadataPattern.Replace(key.ToString(), string.Empty)}-counter";
                var movieId = _metadataPattern.Replace(key.ToString(), string.Empty);
                var value = await _temporaryMetadataStorage.GetStringAsync(transactionKey);
                _ = value switch
                {
                    "2" => await _storagesSynchronizationService.SynchronizeStorages(movieId, transactionKey),
                    "3" => await _temporaryStoragesCleaner.ClearStorages(movieId, transactionKey),
                    _ => false
                };
            }

            await Task.Delay(3000);
        }
    }

    [GeneratedRegex("-posters|-trailers")]
    private static partial Regex MetadataKey();
}