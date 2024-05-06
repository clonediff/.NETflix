using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using API.Shared;
using DataAccess;
using Domain.Entities;
using DotNetflixMobileAPI.GraphQL.Mutations;
using DotNetflixMobileAPI.GraphQL.Queries;
using Microsoft.AspNetCore.Identity;
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
    .AddAuthorization()
    .ModifyRequestOptions(x => x.IncludeExceptionDetails = true)
    .AddQueryType<FilmQuery>()
    .AddMutationType<AuthorizationMutation>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services
    .AddCors()
    .Configure<EmailConfig>(builder.Configuration.GetSection("SmtpSetting"))
    .AddApplicationDb(connectionString)
    .AddIdentity<User, IdentityRole>(builder.Environment.IsDevelopment() ? SetupDevelopmentIdentityOptions : _ => {})
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders().Services
    .RegisterServices(builder.Configuration)
    .AddJwtAuthorization(builder.Configuration)
    .ConfigureHttpJsonOptions(options => 
    {
        options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.SerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    });

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
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

app.MapGraphQL(new PathString("/graphql"));

app.Run();