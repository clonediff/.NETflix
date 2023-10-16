using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using DotNetflixAPI.Middleware;
using DataAccess;
using DotNetflixAPI.Extensions;
using DotNetflixAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddSignalR();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddCors()
	.ConfigureOptions(builder.Configuration)
	.AddMassTransitRabbitMq(builder.Configuration)
	.AddApplicationDb<ApplicationDBContext>(connectionString, builder.Environment)
	.AddAuth()
	.AddGoogleOAuth(builder.Configuration)
	.RegisterServices()
	.AddControllers()
	.AddJsonOptions(options => 
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
	});

var app = builder.Build();

if (app.Environment.IsDevelopment())
	app.MapBackupData();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

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

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chatHub");
app.MapHub<SupportChatHub>("/supportChatHub");

app.Run();
