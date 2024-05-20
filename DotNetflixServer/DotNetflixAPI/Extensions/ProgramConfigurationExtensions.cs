using Domain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Services.Infrastructure.EmailService;
using Services.Infrastructure.GoogleOAuth.Google;
using Services.Shared.FilmVisitsService;

namespace DotNetflixAPI.Extensions;

public static class ProgramConfigurationExtensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("User", pb => pb
                .RequireRole("user", "manager", "admin"));
            options.AddPolicy("Manager", pb => pb
                .RequireRole("manager", "admin"));
            options.AddPolicy("Admin", pb => pb
                .RequireRole("admin"));
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.HttpOnly = true;
        });

        return services;
    }

    public static IServiceCollection AddGoogleOAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CookieAuthenticationOptions>(IdentityConstants.ExternalScheme, options =>
        {
            options.LoginPath = new PathString("/api/oauth/google");

            var del = options.Events.OnRedirectToAccessDenied;
            options.Events.OnRedirectToAccessDenied = async ctx =>
            {
                var signInManager = ctx.HttpContext.RequestServices.GetRequiredService<SignInManager<User>>();

                if (ctx.Request.Path.StartsWithSegments(new PathString("/api/oauth/google")))
                {
                    var properties = signInManager.ConfigureExternalAuthenticationProperties(
                        GoogleDefaults.AuthenticationScheme, configuration.GetValue<string>("ApiOAuth"));
                    await ctx.HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
                    return;
                }

                await del(ctx);
            };
        });

        services.AddAuthentication()
            .AddOAuth<GoogleOptions, GoogleOAuthHandler>(GoogleDefaults.AuthenticationScheme, options =>
            {
                options.ClientId = configuration.GetSection("GoogleOAuth")
                    .GetValue<string>("ClientId") ?? string.Empty;
                options.ClientSecret = configuration.GetSection("GoogleOAuth")
                    .GetValue<string>("ClientSecret") ?? string.Empty;
            });
        
        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailConfig>(configuration.GetSection("SmtpSetting"));
        services.Configure<GoogleSecrets>(configuration.GetSection("GoogleOAuth"));
        
        return services;
    }

    public static IApplicationBuilder UseFilmVisits(this WebApplication app)
    {
        app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/films/GetFilmById"), application =>
        {
            using var scope = application.ApplicationServices.CreateScope();
            var filmVisitsService = scope.ServiceProvider.GetRequiredService<IFilmVisitsService>();

            application.Use(async (context, next) =>
            {
                await next(context);
                
                if (context.Response.StatusCode == 200)
                {
                    var filmId = int.Parse(context.Request.Query["id"]!);
                    await filmVisitsService.HandleFilmVisitAsync(filmId);
                }
            });
        });

        return app;
    }
}
