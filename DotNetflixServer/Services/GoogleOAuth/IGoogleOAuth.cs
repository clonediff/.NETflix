using System.Text.Json;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Services.GoogleOAuth;

public interface IGoogleOAuth
{
    Task<bool> ExternalLoginAsync(string code);
    protected internal Task<OAuthTokenResponse> GetAccessToken(string code);
    protected internal Task<bool> CanGetUserInfoAsync(OAuthTokenResponse tokens);
    protected internal Task<string?> GetProviderKeyAsync(JsonElement tokens);
}