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

builder.Services.AddControllers()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
		});

builder.Services.AddTransient<IHashPassword, HashPassword>();
builder.Services.AddTransient<IFilmProvider, FilmProvider>();

var app = builder.Build();

#region backupData
//app.Map("/backupData", (ApplicationDBContext db) =>
//{
//	var folderPath = "./jsons";
//	var dbSets = typeof(ApplicationDBContext).GetProperties()
//		.Where(x => x.PropertyType.IsGenericType && 
//			x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
//	var ofType = typeof(Enumerable).GetMethod(nameof(Enumerable.OfType));
//	foreach (var dbSet in dbSets)
//	{
//		var genreic = dbSet.PropertyType.GetGenericArguments();
//		var genericOfType = ofType.MakeGenericMethod(genreic[0]);
//		var data = genericOfType.Invoke(null, new[] { (IEnumerable)dbSet.GetValue(db) });
//		var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
//		{
//			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//			ReferenceHandler = ReferenceHandler.IgnoreCycles
//		});
//		File.WriteAllText(Path.Combine(folderPath, $"{genreic[0].Name}.txt"), json);
//	}
//});
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(b => b.WithOrigins("http://localhost:3000"));

app.MapControllers();

app.Run();
