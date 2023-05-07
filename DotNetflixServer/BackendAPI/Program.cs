using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using BackendAPI.Middleware;
using DataAccess;
using DataAccess.Entities.IdentityLogic;
using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Services.AuthService;
using Services.FilmService;
using Services.GoogleOAuth;
using Services.GoogleOAuth.Google;
using Services.MailSenderService;
using Services.TwoFAService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
builder.Services.Configure<GoogleSecrets>(builder.Configuration.GetSection("GoogleOAuth"));

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
	    if (builder.Environment.IsDevelopment())
        {
            options.User.RequireUniqueEmail = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        }
    })
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ExternalScheme, options =>
{
	//TODO: Перенести это в отдельный класс как с гуглом. Сделать такие же классы для vk 
	//options.LoginPath = new PathString("/OAuth/ExternalLogin");
    
	options.LoginPath = new PathString("/api/oauth/google");

	var del = options.Events.OnRedirectToAccessDenied;
	options.Events.OnRedirectToAccessDenied = async ctx =>
	{
		var signInManager = ctx.HttpContext.RequestServices.GetRequiredService<SignInManager<User>>();
		
		if (ctx.Request.Path.StartsWithSegments(new PathString("/api/oauth/google")))
		{
			var properties = signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.AuthenticationScheme,
				"https://localhost:7289/api/oauth/google");
			await ctx.HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
			return;
		}

		await del(ctx);
	};
});

builder.Services.AddAuthentication()
	.AddOAuth<GoogleOptions, GoogleOAuthHandler>(GoogleDefaults.AuthenticationScheme,options =>
	{
		options.ClientId = builder.Configuration.GetSection("GoogleOAuth")
			.GetValue<string>("ClientId") ?? string.Empty;
		options.ClientSecret = builder.Configuration.GetSection("GoogleOAuth")
			.GetValue<string>("ClientSecret") ?? string.Empty;
	});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", pb => pb
        .RequireClaim("level", "user","manager", "admin"));
    options.AddPolicy("manager", pb => pb
	    .RequireClaim("level", "manager", "admin"));
    options.AddPolicy("admin", pb => pb
        .RequireClaim("level", "admin"));
});

builder.Services.AddControllers()
	.AddJsonOptions(options => 
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
	});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.SameSite = SameSiteMode.None;
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	options.Cookie.HttpOnly = true;
});

builder.Services.AddMemoryCache();
builder.Services.AddTransient<IFilmProvider, FilmProvider>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITwoFAService, TwoFAService>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPasswordGenerator, PasswordGenerator>();
builder.Services.AddScoped<IGoogleOAuth, GoogleOAuthService>();

var app = builder.Build();

#region backupData
app.Map("/backupData", (ApplicationDBContext db) =>
{
	var folderPath = "./jsons";
	var dbSets = typeof(ApplicationDBContext).GetProperties()
		.Where(x => x.PropertyType.IsGenericType && 
			x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
	var ofType = typeof(Enumerable).GetMethod(nameof(Enumerable.OfType));
	foreach (var dbSet in dbSets)
	{
		var generic = dbSet.PropertyType.GetGenericArguments();
		var genericOfType = ofType.MakeGenericMethod(generic[0]);
		var data = genericOfType.Invoke(null, new[] { (IEnumerable)dbSet.GetValue(db) });
		var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
		{
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			ReferenceHandler = ReferenceHandler.IgnoreCycles
		});
		File.WriteAllText(Path.Combine(folderPath, $"{generic[0].Name}.txt"), json);
	}
}).RequireAuthorization("admin");
#endregion

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
			if (builder.Environment.IsDevelopment())
			{
				// Only add this to allow testing with localhost, remove this line in production!
				if (origin.ToLower().StartsWith("http://localhost") || origin.ToLower().StartsWith("https://localhost")) return true;
			}

			if (builder.Environment.IsProduction())
			{
				// Insert your production domain here.
				//TODO: На деплое свой домейн нужно будет прописать сюда
				if (origin.ToLower().StartsWith("https://dev.mydomain.com")) return true;   
			}
			return false;
		})
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(_ => {});

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

/*app.UseSpa(spaBuilder =>
{
	spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:3000");
});*/

app.Run();
