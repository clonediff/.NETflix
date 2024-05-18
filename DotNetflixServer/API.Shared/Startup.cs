﻿using System.Text;
using DataAccess;
using DotNetflix.Application;
using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Infrastructure.EmailService;
using Services.Infrastructure.GoogleOAuth;
using Services.Shared.JwtGenerator;
using Services.Shared.MovieMetaDataService;
using Services.Shared.SupportChatService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Configuration.Shared.RabbitMq;
using MassTransit;
using Services.Shared.FilmVisitsService;
using RabbitMQ.Client;
using static Configuration.Shared.Constants.QueueExchanges;

namespace API.Shared;

public static class Startup
{
    public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services,
        RabbitMqConfig rabbitMqConfig, params Type[] consumers)
    {
        services.AddMassTransit(configurator =>
        {
            foreach (var consumer in consumers)
            {
                configurator.AddConsumer(consumer);
            }
     
            configurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(rabbitMqConfig.FullHostname);
                cfg.ConfigureEndpoints(ctx);
            });
        });

        return services;
    }

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
        string? connectionString)
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
        services.AddScoped<IJwtGenerator, JwtGenerator>();
        services.AddScoped<IFilmVisitsService, FilmVisitsService>();
        services.AddApplicationServices();
        
        return services;
    }

    public static IServiceCollection AddJwtAuthorization(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, //Todo надо ли это и нужно ли делать refresh для этого?
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddAuthorizationBuilder();
        
        return services;
    }

    public static IServiceCollection AddFilmVisits(this IServiceCollection services, RabbitMqConfig config)
    {
        services.AddSingleton(_ =>
        {
            var factory = new ConnectionFactory
            {
                HostName = config.Hostname,
                CredentialsProvider = new BasicCredentialsProvider(config.Username, config.Password)
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(FilmVisitsExchangeName, ExchangeType.Direct);

            return channel;
        });

        return services;
    }
}