using Microsoft.Extensions.Caching.Distributed;

namespace DotNetflix.Storage.Services.TemporaryStorageMetadata;

public class RedisStorageService : ITemporaryStorageMetadataService
{
    private readonly IDistributedCache _cache;

    public RedisStorageService(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public async Task SetStringAsync(string data, string dataIdentifier, uint absoluteExpiration)
    {
        await _cache.SetStringAsync(
            dataIdentifier,
            data,
            new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(absoluteExpiration)
            });
    }

    public async Task RemoveAsync(string dataIdentifier)
    {
        await _cache.RemoveAsync(dataIdentifier);
    }

    public async Task<string?> GetStringAsync(string dataIdentifier)
    {
        return await _cache.GetStringAsync(dataIdentifier);
    }
}