using Microsoft.Extensions.Options;

namespace Services.GoogleOAuth;

public class GoogleOAuthService
{
    private GoogleOAuth OAuth;

    public GoogleOAuthService(IOptions<GoogleOAuth> oAuth)
    {
        OAuth = oAuth.Value;
    }
    
    
}