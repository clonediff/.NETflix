using Microsoft.AspNetCore.Mvc;
using Services.Infrastructure.GoogleOAuth;
using Services.Infrastructure.GoogleOAuth.Google;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/oauth")]
public class OAuthController : ControllerBase
{
    private readonly IGoogleOAuth _googleOAuthService;
    private readonly IConfiguration _configuration;

    public OAuthController(IGoogleOAuth googleOAuthService, IConfiguration configuration)
    {
        _googleOAuthService = googleOAuthService;
        _configuration = configuration;
    }

    [HttpGet("google")]
    public async Task<IActionResult> ExternalLoginAsync([FromQuery] GoogleCallback callback)
    {
        var baseUrl = _configuration["FrontendBaseUrl"];
        var canExternalLoginAsync = await _googleOAuthService.ExternalLoginAsync(callback.Code);
        if (canExternalLoginAsync)
            return Redirect($"{baseUrl}/");

        return Redirect($"{baseUrl}/login");
    }
}