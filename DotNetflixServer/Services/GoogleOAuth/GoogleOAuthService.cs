using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using DataAccess.Entities.IdentityLogic;
using Google.Apis.Auth;
using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services.GoogleOAuth.Google;

namespace Services.GoogleOAuth;

public class GoogleOAuthService : IGoogleOAuth
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IPasswordGenerator _passwordGenerator;
    private readonly HttpClient _client;
    private readonly GoogleSecrets _googleSecrets;
    private readonly PasswordOptions _passwordOptions;
    private readonly HttpContext HttpContext;

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
        HttpContext = contextAccessor.HttpContext;
    }


    public async Task<bool> ExternalLoginAsync(string code)
    {
        var tokens = await ((IGoogleOAuth) this).GetAccessToken(code);
        
        if (tokens.Error == null)
        {
            var canGetUser = await ((IGoogleOAuth) this).CanGetUserInfoAsync(tokens);

            if (!canGetUser)
                return false;

            var providerKey = await ((IGoogleOAuth) this).GetProviderKeyAsync(tokens.Response!.RootElement);

            if (providerKey == null)
                return false;
            
            var info = new UserLoginInfo(GoogleDefaults.ProviderName, providerKey,
                GoogleDefaults.AuthenticationScheme);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
        
            if (user == null)
            {
                user = await _userManager.GetUserAsync(HttpContext.User);
                if (user == null)
                {
                    var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                    var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
                    var password = _passwordGenerator.GeneratePassword(_passwordOptions);

                    var existingUser = await _userManager.FindByEmailAsync(email);
                    if (existingUser != null)
                    {
                        await _userManager.AddLoginAsync(existingUser, info);
                        
                    }
                    else
                    {
                        user = new User {Email = email, UserName = username};
                        var identityRes = await _userManager.CreateAsync(user, password);
                
                        if (identityRes.Succeeded)
                        {
                            var addLoginAsyncRes = await _userManager.AddLoginAsync(user, info);
                            if(addLoginAsyncRes.Succeeded)
                                await _userManager.AddClaimAsync(user, new Claim("level", "user"));
                        }
                    }
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, false);
            return true;
        }

        return false;
    }

    async Task<OAuthTokenResponse> IGoogleOAuth.GetAccessToken(string code)
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

        var resp = await _client.SendAsync(request, HttpContext.RequestAborted);
        var respContent = await resp.Content.ReadAsStringAsync(HttpContext.RequestAborted);
        
        return resp.IsSuccessStatusCode switch
        {
            true => OAuthTokenResponse.Success(JsonDocument.Parse(respContent)),
            false => OAuthTokenResponse.Failed(new Exception($"OAuth token endpoint failure: Status: {resp.StatusCode};Headers: {resp.Headers};Body: {respContent};"))
        };
    }

    async Task<bool> IGoogleOAuth.CanGetUserInfoAsync(OAuthTokenResponse tokens)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, GoogleDefaults.UserInformationEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

        var response = await _client.SendAsync(request, HttpContext.RequestAborted);
        if (response.IsSuccessStatusCode)
        {
            using var payload = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync(HttpContext.RequestAborted));
            
            var identity = new ClaimsIdentity(IdentityConstants.ExternalScheme);
            
            var externalAuthenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.ProviderName,"https://localhost:3000/");
            
            var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), externalAuthenticationProperties,
                HttpContext, new AuthenticationScheme(GoogleDefaults.AuthenticationScheme, GoogleDefaults.AuthenticationScheme, typeof(GoogleOAuthHandler)),
                new GoogleOptions(), _client, tokens, payload.RootElement);
            
            context.RunClaimActions();
            HttpContext.User = context.Principal?.Clone()!;
            return true;
        }

        return false;
    }

    async Task<string?> IGoogleOAuth.GetProviderKeyAsync(JsonElement tokens)
    {
        var canGetIdToken = tokens.TryGetProperty("id_token", out var idToken);

        if (!canGetIdToken)
            return null;
        
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { _googleSecrets.ClientId }
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken.GetString(), settings);
        return payload.Subject;
    }
}