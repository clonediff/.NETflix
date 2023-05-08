using Microsoft.Extensions.Caching.Memory;
using Services.MailSenderService;
using DataAccess.Entities.IdentityLogic;

namespace Services.TwoFAService
{
    public class TwoFAService : ITwoFAService
    {
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _memoryCache;

        public TwoFAService(IEmailService emailService, IMemoryCache memoryCache)
        {
            _emailService = emailService;
            _memoryCache = memoryCache;
        }
        public async Task SendCodeAsync(User user)
        {
            var code = GenerateCode();
            await _emailService.SendEmailAsync(user.Email, "Код для двухфакторной аутентификации", code);
            _memoryCache.Set(user.Email, code, TimeSpan.FromMinutes(5));
        }

        public bool CheckCode(User user, string code)
        {
            return _memoryCache.TryGetValue<string>(user.Email, out var savedCode) && savedCode == code;
        }

        private string GenerateCode()
        {
            return new Random().Next().ToString();
        }
    }
}
