using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataAccess;
using DataAccess.Entities.IdentityLogic;
using Microsoft.AspNetCore.Identity;
using Services.FilmService;
using Services.MailSenderService;
using Services.TwoFAService;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using DataAccess.Entities.BusinessLogic;
using BackendAPI.Data;

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
	.AddJsonOptions(options => 
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
	});

builder.Services.AddMemoryCache();
builder.Services.AddTransient<IFilmProvider, FilmProvider>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITwoFAService, TwoFAService>();

var app = builder.Build();

#region backupData
app.Map("/backupData", async (ApplicationDBContext db) =>
{
	var folderPath = "../DataAccess/jsons";
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(pb => pb
	.AllowAnyHeader()
	.AllowCredentials()
	.WithOrigins("http://localhost:3000")
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

app.UseSpa(spaBuilder =>
{
	spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:3000");
});

app.Run();
