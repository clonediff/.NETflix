using DataAccess;
using DotNetflix.Application;
using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Infrastructure.EmailService;
using Services.Infrastructure.GoogleOAuth;
using Services.Shared.MovieMetaDataService;
using Services.Shared.SupportChatService;

namespace API.Shared;

public static class Startup
{
    public static void SetupDevelopmentIdentityOptions(IdentityOptions options)
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
    
    public static IServiceCollection AddApplicationDb(this IServiceCollection services,
        string? connectionString, bool isDevelopment)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.LogTo(Console.WriteLine);
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<DbContext, ApplicationDBContext>();
        
        return services;
    }
    
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.AddScoped<IEmailService, EmailService>();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
        services.AddHttpClient<ISupportChatService, SupportChatService>(client =>
        {
            client.BaseAddress = new Uri(configuration["StorageApiBaseUrl"]!);
        });
        services.AddHttpClient<IMovieMetaDataService, MovieMetaDataService>(client =>
        {
            client.BaseAddress = new Uri(configuration["StorageApiBaseUrl"]!);
        });
        services.AddHttpClient<IGoogleOAuth, GoogleOAuthService>();
        services.AddScoped<IPasswordGenerator, PasswordGenerator>();
        services.AddApplicationServices();
        
        return services;
    }
}