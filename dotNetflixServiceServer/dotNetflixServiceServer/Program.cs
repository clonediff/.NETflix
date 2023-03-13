using dotNetflixServiceServer;
using dotNetflixServiceServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("dotNetflixDB")));

builder.Services.AddTransient<IHashPassword, HashPassword>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
