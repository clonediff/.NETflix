using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Films;
using Contracts.Admin.Films.Details;

namespace Services.Admin.Abstractions;

public interface IFilmService
{
    Task<int> GetFilmsCountAsync();
    Task AddFilmAsync(AddFilmDto dto);
    Task<PaginationDataDto<EnumDto<int>>> GetFilmsFilteredAsync(int page, string? name);
    Task DeleteFilmAsync(int id);
    Task<MovieDto> GetFilmById(int id);
    Task UpdateFilmAsync(UpdateFilmDto dto);
    Task<MovieDetailsDto> GetFilmDetailsAsync(int id);
}