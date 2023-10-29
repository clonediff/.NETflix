using DataAccess;
using Domain.Entities;
using DotNetflix.Admin.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Admin;
using Services.Admin.Abstractions;
using Services.Infrastructure.EmailService;
using Services.Shared.SupportChatService;

namespace DotNetflixAdminAPI.Extensions;

public static class ProgramConfigurationExtensions
{
    public static IServiceCollection AddApplicationDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.LogTo(Console.WriteLine);
                options.UseSqlServer(connectionString);
            })
            .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>();

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

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IAdminSupportChatService, AdminSupportChatService>();
        services.AddScoped<ISupportChatService, SupportChatService>();
        services.AddApplicationServices();

        return services;
    }

    public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailConfig>(configuration.GetSection("SmtpSetting"));
        return services;
    }

    public static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

        await using var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

        await dbContext.Database.MigrateAsync();
    }
}