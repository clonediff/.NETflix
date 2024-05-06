using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using API.Shared;
using DataAccess;
using Domain.Entities;
using DotNetflix.Application.Features.Authentication.Commands.Login;
using DotNetflixMobileAPI.GraphQL;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Infrastructure.EmailService;
using Services.Shared;
using static API.Shared.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddGrpcClient<PaymentService.PaymentServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["PaymentGrpcAddress"]!);
});

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(x => x.IncludeExceptionDetails = true)
    .AddMutationType<Mutations>()
    .AddQueryType<Queries>()
    .AddErrorFilter<ExceptionToErrorHandler>()
    .AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services
    .AddCors()
    .AddAuthorization()
    .Configure<EmailConfig>(builder.Configuration.GetSection("SmtpSetting"))
    .AddApplicationDb(connectionString)
    .AddIdentity<User, IdentityRole>(builder.Environment.IsDevelopment() ? SetupDevelopmentIdentityOptions : _ => { })
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders().Services
    .RegisterServices(builder.Configuration)
    .AddHttpContextAccessor()
    .ConfigureHttpJsonOptions(options => 
    {
        options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.SerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", pb => pb
        .RequireRole("user", "manager", "admin"));
    options.AddPolicy("Manager", pb => pb
        .RequireRole("manager", "admin"));
    options.AddPolicy("Admin", pb => pb
        .RequireRole("admin"));
}).ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseCors(pb =>
    pb
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin =>
        {
            if (string.IsNullOrWhiteSpace(origin)) return false;

            // Only add this to allow testing with localhost, remove this line in production!

            return origin.ToLower().StartsWith("http://localhost") || origin.ToLower().StartsWith("https://localhost");
        })
);

app.MapGet("/auth_test", async ([FromServices] IMediator mediator, [FromQuery] string username,
    [FromQuery] string password, [FromQuery] bool remember) =>
{
    var loginCommand = new LoginCommand(username, password, remember);
    var result = await mediator.Send(loginCommand);
    return result.Match(success: Results.Ok,
        failure: Results.BadRequest);
});

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL(new PathString("/graphql"));

app.Run();