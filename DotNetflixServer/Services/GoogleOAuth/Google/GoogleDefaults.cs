namespace Services.GoogleOAuth.Google;

public static class GoogleDefaults
{
    
    /// <summary>
    /// Google authorization policy
    /// </summary>
    public const string AuthorizationPolicy = "Google_OAuth";

    /// <summary>
    /// Google Identity Claim. Used for authorization policy
    /// </summary>
    public const string IdentityClaim = "Google-Token";

    /// <summary>
    /// The default scheme for Google authentication. Defaults to <c>Google</c>.
    /// </summary>
    public const string AuthenticationScheme = "Google";

    /// <summary>
    /// The default display name for Google authentication. Defaults to <c>Google</c>.
    /// </summary>
    public const string ProviderName = "GoogleProvider";

    /// <summary>
    /// The default endpoint used to perform Google authentication.
    /// </summary>
    /// <remarks>
    /// For more details about this endpoint, see <see href="https://developers.google.com/identity/protocols/oauth2/web-server#httprest"/>.
    /// </remarks>
    public const string AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";

    /// <summary>
    /// The OAuth endpoint used to exchange access tokens.
    /// </summary>
    public const string TokenEndpoint = "https://oauth2.googleapis.com/token";

    /// <summary>
    /// The Google endpoint that is used to gather additional user information.
    /// </summary>
    /// <remarks>
    /// For more details about this endpoint, see <see href="https://developers.google.com/apis-explorer/#search/oauth2/oauth2/v2/"/>.
    /// </remarks>
    public const string UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
}
