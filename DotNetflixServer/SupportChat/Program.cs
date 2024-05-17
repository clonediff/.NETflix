using Configuration.Shared.RabbitMq;
using SupportChat.BackgroundServices;
using SupportChat.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<NonDuplicatedMessagesHandler>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitMqConfig = builder.Configuration.GetSection(RabbitMqConfig.SectionName).Get<RabbitMqConfig>()!;
builder.Services
    .AddApplicationDb(connectionString)
    .AddMasstransitRabbitMq(rabbitMqConfig);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
