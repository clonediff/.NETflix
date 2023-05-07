using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Services.GoogleOAuth.Google;

public class GoogleOptions : OAuthOptions
{
    public GoogleOptions()
    {
        Events = new GoogleEvents();
        SignInScheme = IdentityConstants.ExternalScheme;
        CallbackPath = "/googleoauth/google-cb";
        SaveTokens = false;

        Scope.Clear();
        
        AuthorizationEndpoint = GoogleDefaults.AuthorizationEndpoint;
        TokenEndpoint = GoogleDefaults.TokenEndpoint;
        UserInformationEndpoint = GoogleDefaults.UserInformationEndpoint;
        
        //Scope.Add(GoogleDefaults.ScopeEndpoint);
        Scope.Add("openid");
        Scope.Add("profile");
        Scope.Add("email");

        ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
        ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
        ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
        ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
        ClaimActions.MapJsonKey("urn:google:profile", "link");
        ClaimActions.MapJsonKey(ClaimTypes.Email, "email");  
    }
    
    
}