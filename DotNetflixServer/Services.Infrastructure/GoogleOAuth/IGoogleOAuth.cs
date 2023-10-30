using System.Text.Json;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Services.Infrastructure.GoogleOAuth;

public interface IGoogleOAuth
{
    Task<bool> ExternalLoginAsync(string code);
}