using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Services.GoogleOAuth.Google;

public class GoogleEvents : OAuthEvents
{
    public override async Task CreatingTicket(OAuthCreatingTicketContext context)
    {
        var authenticationHandlerProvider =
            context.HttpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
        var handler = await authenticationHandlerProvider.GetHandlerAsync(context.HttpContext, IdentityConstants.ExternalScheme);
        var authResult = await handler?.AuthenticateAsync()!;
        if (!authResult.Succeeded)
        {
            context.Fail("External authentication failed");
            return;
        }

        var claimsPrincipal = authResult.Principal;
        context.Principal = claimsPrincipal.Clone();
        var identity =
            context.Principal.Identities.First(x => x.AuthenticationType == IdentityConstants.ExternalScheme);
        identity.AddClaims(new[] {new Claim(GoogleDefaults.IdentityClaim, Guid.NewGuid().ToString())});
        context.RunClaimActions();
    }
}