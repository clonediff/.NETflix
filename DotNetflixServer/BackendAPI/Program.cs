using BackendAPI;
using BackendAPI.Services;
using DBModels.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services;
using DBModels.IdentityLogic;
using Microsoft.AspNetCore.Identity;
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

#region badPractise
/*builder.Services.ConfigureApplicationCookie(options =>
{
	if (builder.Environment.IsDevelopment())
    {
		options.Cookie.SameSite = SameSiteMode.None;
		options.Cookie.HttpOnly = true;
		options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    }
});*/
#endregion

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", pb => pb
        .RequireClaim("level", "user", "admin"));
    options.AddPolicy("admin", pb => pb
        .RequireClaim("level", "admin"));
});

builder.Services.AddControllers()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
		});

builder.Services.AddMemoryCache();
builder.Services.AddTransient<IHashPassword, HashPassword>();
builder.Services.AddTransient<IFilmProvider, FilmProvider>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITwoFAService, TwoFAService>();

var app = builder.Build();

app.UseCors(b => b
	.WithOrigins("http://localhost:3000")
	.AllowAnyHeader()
	.AllowCredentials());

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
});
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();

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

app.UseAuthentication();

app.UseAuthorization();

app.UseSpa(spaBuilder =>
{
    spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:3000");
});

app.Run();
