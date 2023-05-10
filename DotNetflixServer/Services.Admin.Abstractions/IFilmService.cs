using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Films;

namespace Services.Admin.Abstractions;

public interface IFilmService
{
    Task<int> GetFilmsCountAsync();
    Task AddFilmAsync(AddFilmDto dto);
    Task<PaginationDataDto<string>> GetFilmsFilteredAsync(int page, string? name);
}