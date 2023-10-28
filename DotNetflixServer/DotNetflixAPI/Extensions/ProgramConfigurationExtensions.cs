using Configuration.Shared.RabbitMq;
using DataAccess;
using Domain.Entities;
using DotNetflix.Application;
using DotNetflixAPI.Middleware;
using IdentityPasswordGenerator;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstractions;
using Services.Infrastructure.EmailService;
using Services.Infrastructure.GoogleOAuth;
using Services.Infrastructure.GoogleOAuth.Google;
using Services.Shared.SupportChatService;

namespace DotNetflixAPI.Extensions;

public static class ProgramConfigurationExtensions
{
    public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services,
        RabbitMqConfig rabbitMqConfig)
    {
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(rabbitMqConfig.FullHostname);
                cfg.ConfigureEndpoints(ctx);
            });
        });
        
        return services;
    }

    public static IServiceCollection AddApplicationDb(this IServiceCollection services,
        string? connectionString, IWebHostEnvironment environment)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.LogTo(Console.WriteLine);
                options.UseSqlServer(connectionString);
            })
            .AddIdentity<User, IdentityRole>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.User.RequireUniqueEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                }
            })
            .AddEntityFrameworkStores<ApplicationDBContext>()
            .AddDefaultTokenProviders();

        return services;
    }

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

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IChatStorage, ChatStorage>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IAuthService, AuthServiceImpl>();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
        services.AddHttpClient();
        services.AddHttpContextAccessor();
        services.AddScoped<IPasswordGenerator, PasswordGenerator>();
        services.AddScoped<IGoogleOAuth, GoogleOAuthService>();
        services.AddScoped<ISupportChatService, SupportChatService>();
        services.AddApplicationServices();
        
        return services;
    }
}
