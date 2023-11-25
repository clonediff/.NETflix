using Configuration.Shared.RabbitMq;
using SupportChat.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitMqConfig = builder.Configuration.GetSection(RabbitMqConfig.SectionName).Get<RabbitMqConfig>()!;
builder.Services
    .AddApplicationDb(connectionString)
    .AddMasstransitRabbitMq(rabbitMqConfig);

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
