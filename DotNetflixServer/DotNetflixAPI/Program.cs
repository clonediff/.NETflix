using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using API.Shared;
using Configuration.Shared.RabbitMq;
using DataAccess;
using Domain.Entities;
using Services.Shared;
using DotNetflixAPI.Extensions;
using DotNetflixAPI.Hubs;
using Microsoft.AspNetCore.Identity;
using DotNetflixAPI.Consumers;
using static API.Shared.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddSignalR(options =>
{
	options.MaximumReceiveMessageSize = 10 * 1024 * 1024;
});

builder.Services.AddGrpcClient<PaymentService.PaymentServiceClient>(options =>
{
	options.Address = new Uri(builder.Configuration["PaymentGrpcAddress"]!);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitMqConfig = builder.Configuration.GetSection(RabbitMqConfig.SectionName).Get<RabbitMqConfig>()!;
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddCors()
	.ConfigureOptions(builder.Configuration)
	.AddMassTransitRabbitMq(rabbitMqConfig, typeof(SignalRSynchronizationConsumer))
	.AddFilmVisits(rabbitMqConfig)
	.AddApplicationDb(connectionString)
	.AddIdentity<User, IdentityRole>(builder.Environment.IsDevelopment() ? SetupDevelopmentIdentityOptions : _ => {})
	.AddEntityFrameworkStores<ApplicationDBContext>()
	.AddDefaultTokenProviders().Services
	.AddAuth()
	.AddGoogleOAuth(builder.Configuration)
	.RegisterServices(builder.Configuration)
	.AddHttpContextAccessor()
	.AddControllers()
	.AddJsonOptions(options => 
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
	});

var app = builder.Build();

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

app.UseFilmVisits();

app.MapHub<ChatHub>("/chatHub");
app.MapHub<SupportChatHub>("/supportChatHub");

app.Run();
