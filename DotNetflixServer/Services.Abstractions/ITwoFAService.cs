namespace Services.Abstractions;

public interface ITwoFAService
{
    public Task SendCodeAsync(string email);
    public bool CheckCode(string email, string code);
}