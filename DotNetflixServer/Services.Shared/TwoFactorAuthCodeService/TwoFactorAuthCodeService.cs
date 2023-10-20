using Microsoft.Extensions.Caching.Memory;

namespace Services.Shared.TwoFactorAuthCodeService;

public class TwoFactorAuthCodeService : ITwoFactorAuthCodeService
{
    private readonly IMemoryCache _memoryCache;

    public TwoFactorAuthCodeService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void SetCode(string key, string code, TimeSpan absoluteExpiration)
    {
        _memoryCache.Set(key, code, absoluteExpiration);
    }

    public bool CheckCode(string key, string codeToCheck)
    {
        return _memoryCache.TryGetValue<string>(key, out var savedCode) && savedCode == codeToCheck;
    }
}