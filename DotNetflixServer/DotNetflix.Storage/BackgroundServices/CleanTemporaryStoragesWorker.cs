using DotNetflix.Storage.Services.S3;
using StackExchange.Redis;

namespace DotNetflix.Storage.BackgroundServices;

public class CleanTemporaryStoragesWorker : BackgroundService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IS3StorageService _s3StorageService;
    private readonly string? _redisConnectionString;
    private readonly string _bucketId;
    private readonly PeriodicTimer _timer = new(TimeSpan.FromDays(1));

    public CleanTemporaryStoragesWorker(IConnectionMultiplexer connectionMultiplexer,
        IConfiguration configuration, IS3StorageService s3StorageService)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _s3StorageService = s3StorageService;
        _bucketId = configuration.GetSection("TemporaryBucketName").Get<string>()!;
        _redisConnectionString = configuration.GetConnectionString("Redis");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if(!await _s3StorageService.BucketExistAsync(_bucketId))
            await _s3StorageService.CreateBucketAsync(_bucketId);

        while (await _timer.WaitForNextTickAsync(stoppingToken)
               && !stoppingToken.IsCancellationRequested)
        {
            var server = _connectionMultiplexer.GetServer(_redisConnectionString!);
            if (await server.DatabaseSizeAsync() != 0)
                await server.FlushDatabaseAsync();
            
            if (!await _s3StorageService.BucketExistAsync(_bucketId))
            {
                await _s3StorageService.CreateBucketAsync(_bucketId);
                continue;
            }
            
            await _s3StorageService.RemoveBucketAsync(_bucketId);
            await _s3StorageService.CreateBucketAsync(_bucketId);
        }
    }
}