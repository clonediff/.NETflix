using DBModels.BusinessLogic;

namespace BackendAPI.Services;

public interface IFilmProvider
{
    public IEnumerable<MovieInfo> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director);
}