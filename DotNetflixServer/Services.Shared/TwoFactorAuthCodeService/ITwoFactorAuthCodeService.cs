namespace Services.Shared.TwoFactorAuthCodeService;

public interface ITwoFactorAuthCodeService
{
    void SetCode(string key, string code, TimeSpan absoluteExpiration);

    bool CheckCode(string key, string codeToCheck);
}