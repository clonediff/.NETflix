using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Domain.Entities;
using Google.Apis.Auth;
using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services.Infrastructure.GoogleOAuth.Google;

namespace Services.Infrastructure.GoogleOAuth;

public class GoogleOAuthService : IGoogleOAuth
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IPasswordGenerator _passwordGenerator;
    private readonly HttpClient _client;
    private readonly GoogleSecrets _googleSecrets;
    private readonly PasswordOptions _passwordOptions;
    private readonly HttpContext _httpContext;

    public GoogleOAuthService(IOptions<GoogleSecrets> googleSecrets,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IPasswordGenerator passwordGenerator,
        HttpClient client,
        IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _passwordGenerator = passwordGenerator;
        _client = client;
        _googleSecrets = googleSecrets.Value;
        _passwordOptions = new PasswordOptions
        {
            RequiredLength = 16,
            RequiredUniqueChars = 6,
        };
        _httpContext = contextAccessor.HttpContext!;
    }


    public async Task<bool> ExternalLoginAsync(string code)
    {
        var tokens = await GetAccessToken(code);

        await RegisterUserClaimsAsync(tokens);

        var providerKey = await GetProviderKeyAsync(tokens.Response!.RootElement);

        if (!providerKey.CanGetKey)
            return false;
            
        var info = new UserLoginInfo(GoogleDefaults.ProviderName, providerKey.Key,
            GoogleDefaults.AuthenticationScheme);

        var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

        if (user != null)
        {
            await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true, true);
            return true;
        }
        
        user = await _userManager.GetUserAsync(_httpContext.User);

        if (user != null)
        {
            await _userManager.AddLoginAsync(user, info);
            await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true, true);
            return true;
        }

        var email = _httpContext.User.FindFirstValue(ClaimTypes.Email);
        var password = _passwordGenerator.GeneratePassword(_passwordOptions);

        var existingUser = await _userManager.FindByEmailAsync(email!);
        
        if (existingUser is null)
        {
            user = new User {Email = email, UserName = email};
            var identityRes = await _userManager.CreateAsync(user, password);
        
            if (identityRes.Succeeded)
            {
                await _userManager.AddLoginAsync(user, info);
                
                await _userManager.AddClaimAsync(user, new Claim("level", "user"));
            }
            var loginRes = await _signInManager
                .ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true, true);
            return loginRes.Succeeded;
        }
        
        await _userManager.AddLoginAsync(existingUser, info);
        await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true, true);
        return true;
    }

    private async Task<OAuthTokenResponse> GetAccessToken(string code)
    {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", _googleSecrets.ClientId),
            new KeyValuePair<string, string>("client_secret", _googleSecrets.ClientSecret),
            new KeyValuePair<string, string>("redirect_uri", "https://localhost:7289/api/oauth/google"),
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", code)
        });
     
        var request = new HttpRequestMessage(HttpMethod.Post, GoogleDefaults.TokenEndpoint);

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = content;
        request.Version = _client.DefaultRequestVersion;

        var resp = await _client.SendAsync(request, _httpContext.RequestAborted);
        var respContent = await resp.Content.ReadAsStringAsync(_httpContext.RequestAborted);
        
        return resp.IsSuccessStatusCode switch
        {
            true => OAuthTokenResponse.Success(JsonDocument.Parse(respContent)),
            false => OAuthTokenResponse.Failed(new Exception($"OAuth token endpoint failure: Status: {resp.StatusCode};Headers: {resp.Headers};Body: {respContent};"))
        };
    }

    private async Task RegisterUserClaimsAsync(OAuthTokenResponse tokens)
    {
        if (tokens.Error != null)
            return;

        var request = new HttpRequestMessage(HttpMethod.Get, GoogleDefaults.UserInformationEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

        var response = await _client.SendAsync(request, _httpContext.RequestAborted);
        if (!response.IsSuccessStatusCode) 
            return;
        using var payload = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync(_httpContext.RequestAborted));
            
        var identity = new ClaimsIdentity(IdentityConstants.ExternalScheme);
            
        var externalAuthenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.ProviderName,"/");
            
        var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), externalAuthenticationProperties,
            _httpContext, new AuthenticationScheme(GoogleDefaults.AuthenticationScheme, GoogleDefaults.AuthenticationScheme, typeof(GoogleOAuthHandler)),
            new GoogleOptions(), _client, tokens, payload.RootElement);
            
        context.RunClaimActions();
        _httpContext.User = context.Principal?.Clone()!;
    }

    private async Task<ProviderKeyDto> GetProviderKeyAsync(JsonElement tokens)
    {
        var canGetIdToken = tokens.TryGetProperty("id_token", out var idToken);

        if (!canGetIdToken)
            return new ProviderKeyDto(string.Empty, false);
        
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { _googleSecrets.ClientId }
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken.GetString(), settings);
        return new ProviderKeyDto(payload.Subject, true);
    }

    private sealed record ProviderKeyDto(string Key, bool CanGetKey);
}