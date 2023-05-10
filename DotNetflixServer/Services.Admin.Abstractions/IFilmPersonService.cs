using Contracts.Admin.Films;

namespace Services.Admin.Abstractions;

public interface IFilmPersonService
{
    IEnumerable<PersonDto> GetAll();
}