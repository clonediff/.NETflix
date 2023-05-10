using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetflixAPI.Middleware;
using DataAccess;
using Domain.Entities;
using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using DotNetflixAPI.Hub;
using Services;
using Services.Abstractions;
using Services.Infrastructure.EmailService;
using Services.Infrastructure.GoogleOAuth;
using Services.Infrastructure.GoogleOAuth.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

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
builder.Services.AddSingleton<IChatStorage, ChatStorage>();
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITwoFAService, TwoFAService>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPasswordGenerator, PasswordGenerator>();
builder.Services.AddScoped<IGoogleOAuth, GoogleOAuthService>();

var app = builder.Build();

#region backupData
app.Map("/backupData", async (ApplicationDBContext db) =>
{
	var folderPath = "../Domain/jsons";
    if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

    await WriteDbSetAsync(db.Countries, folderPath, x => { x.Movies = null; });
    await WriteDbSetAsync(db.CountryMovieInfo, folderPath, x => { x.Country = null; });
    await WriteDbSetAsync(db.CurrencyValues, folderPath);
    await WriteDbSetAsync(db.Fees, folderPath, x => { x.USA = null; x.Russia = null; x.World = null; });
    await WriteDbSetAsync(db.Genres, folderPath, x => { x.Movies = null; });
    await WriteDbSetAsync(db.GenreMovieInfo, folderPath, x => { x.Genre = null; });
    await WriteDbSetAsync(db.Persons, folderPath, x => { x.Proffessions = null; });
    await WriteDbSetAsync(db.PersonProffessionInMovie, folderPath, x => { x.Person = null; });
    await WriteDbSetAsync(db.SeasonsInfos, folderPath, x => { x.MovieInfo = null; });
    await WriteDbSetAsync(db.Types, folderPath);
    await WriteDbSetAsync(db.Movies, folderPath, 
        x => { x.Budget = null; x.Proffessions = null; x.Category = null; x.Countries = null; x.Fees = null; x.Genres = null; x.SeasonsInfo = null; x.Type = null; });
    await WriteDbSetAsync(db.Categories, folderPath);
    await WriteDbSetAsync(db.Professions, folderPath);
});

async Task WriteDbSetAsync<T>(DbSet<T> source, string folderPath, Action<T> changeDataRecord = null!)
	where T : class
{
	var data = source.ToArray();
    if (changeDataRecord is not null) Array.ForEach(data, changeDataRecord);
    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        //WriteIndented = true
    });
    await File.WriteAllTextAsync(Path.Combine(folderPath, $"{typeof(T).Name}.txt"), json);
}
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

app.MapHub<ChatHub>("/chatHub");

/*app.UseSpa(spaBuilder =>
{
	spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:3000");
});*/

app.Run();
