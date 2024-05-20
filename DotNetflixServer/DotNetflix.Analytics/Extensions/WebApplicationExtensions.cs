using DotNetflix.Analytics.Repositories;

namespace DotNetflix.Analytics.Extensions;

public static class WebApplicationExtensions
{
    public static Task CreateFilmVisitsTableAsync(this WebApplication app)
    {
        var filmVisitsRepository = app.Services.GetRequiredService<IFilmVisitsRepository>();

        return filmVisitsRepository.CreateTableAsync();
    }
}