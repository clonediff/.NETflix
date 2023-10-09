using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Services.Admin;
using Services.Admin.Abstractions;
using Services.Infrastructure.EmailService;
using Services.Shared;
using Services.Shared.SupportChatService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.LogTo(Console.WriteLine);
    options.UseSqlServer(connectionString);
});

builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("SmtpSetting"));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", pb => pb
        .RequireRole("user", "manager", "admin"));
    options.AddPolicy("Manager", pb => pb
        .RequireRole("manager", "admin"));
    options.AddPolicy("Admin", pb => pb
        .RequireRole("admin"));
});

builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IFilmPersonService, FilmPersonService>();
builder.Services.AddScoped<IEnumService, EnumService>();
builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
builder.Services.AddScoped<IAdminSupportChatService, AdminSupportChatService>();
builder.Services.AddScoped<ISupportChatService, SupportChatService>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(pb => pb
    .AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:3001")
);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

await using var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

await dbContext.Database.MigrateAsync();

app.Run();
