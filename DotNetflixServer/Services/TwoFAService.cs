using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Memory;
using Services.Abstractions;
using Services.Infrastructure.EmailService;

namespace Services;

public class TwoFAService : ITwoFAService
{
    private readonly IEmailService _emailService;
    private readonly IMemoryCache _memoryCache;

    public TwoFAService(IEmailService emailService, IMemoryCache memoryCache)
    {
        _emailService = emailService;
        _memoryCache = memoryCache;
    }
    
    public async Task SendCodeAsync(string email)
    {
        var code = GenerateCode();
        await _emailService.SendEmailAsync(email, "Код для двухфакторной аутентификации", code);
        _memoryCache.Set(email, code, TimeSpan.FromMinutes(5));
    }

    public bool CheckCode(string email, string code)
    {
        return _memoryCache.TryGetValue<string>(email, out var savedCode) && savedCode == code;
    }

    private string GenerateCode()
    {
        var randomBytes = new byte[4];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        return BitConverter.ToInt32(randomBytes, 0).ToString();
    }
}