using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using DotNetflixAdminAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCors()
    .ConfigureOptions(builder.Configuration)
    .AddApplicationDb(connectionString)
    .AddAuth()
    .RegisterServices(builder.Configuration)
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    });

var app = builder.Build();

app.MapDefaultEndpoints();

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

await app.MigrateDatabaseAsync();

app.Run();
