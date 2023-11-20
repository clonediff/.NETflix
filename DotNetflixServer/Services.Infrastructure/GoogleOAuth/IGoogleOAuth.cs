namespace Services.Infrastructure.GoogleOAuth;

public interface IGoogleOAuth
{
    Task<bool> ExternalLoginAsync(string code);
}