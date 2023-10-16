using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SupportChat.ServicesExtensions;

public static class ApplicationDbExtensions
{
    public static IServiceCollection AddApplicationDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.LogTo(Console.WriteLine);
            options.UseSqlServer(connectionString);
        });
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>();
        return services;
    }
}