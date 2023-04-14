using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.FilmService;
using Services.UserService;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddTransient<IFilmProvider, FilmProvider>();
builder.Services.AddScoped<IUserService, UserService>();

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
    .WithOrigins("http://localhost:3001")
);

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(_ => { });

app.Use((ctx, next) =>
{
    if (ctx.Request.Path.StartsWithSegments("/api"))
    {
        ctx.Response.StatusCode = 404;
        return Task.CompletedTask;
    }

    return next();
});

app.MapControllers();

app.UseHttpsRedirection();

app.UseSpa(spaBuilder =>
{
    spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:3001");
});

app.Run();
