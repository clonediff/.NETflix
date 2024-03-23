using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Configuration.Shared.RabbitMq;
using Services.Shared;
using DotNetflixAPI.Middleware;
using DotNetflixAPI.Extensions;
using DotNetflixAPI.Hubs;

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
	.AddMassTransitRabbitMq(rabbitMqConfig)
	.AddApplicationDb(connectionString, builder.Environment)
	.AddAuth()
	.AddGoogleOAuth(builder.Configuration)
	.RegisterServices(builder.Configuration)
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

app.MapHub<ChatHub>("/chatHub");
app.MapHub<SupportChatHub>("/supportChatHub");

app.Run();
