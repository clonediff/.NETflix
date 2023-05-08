using DtoLibrary.AuthDto;
using Microsoft.AspNetCore.Mvc;
using Services.GoogleOAuth;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api/oauth")]
public class OAuthController : ControllerBase
{
    private readonly IGoogleOAuth _googleOAuthService;
    
    public OAuthController(IGoogleOAuth googleOAuthService)
    {
        _googleOAuthService = googleOAuthService;
    }

    [HttpGet("google")]
    public async Task<IActionResult> ExternalLoginAsync([FromQuery] GoogleCallback callback)
    {
        var canExternalLoginAsync = await _googleOAuthService.ExternalLoginAsync(callback.Code);
        if (canExternalLoginAsync)
            return Redirect("http://localhost:3000");
        
        return Redirect("http://localhost:3000/login");
    }
}