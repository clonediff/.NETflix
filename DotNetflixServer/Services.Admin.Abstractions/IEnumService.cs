using Contracts.Admin.DataRepresentation;

namespace Services.Admin.Abstractions;

public interface IEnumService
{
    IDictionary<string, IEnumerable<EnumDto<int>>> GetAll();
    IEnumerable<EnumDto<int>> GetTypes();
    IEnumerable<EnumDto<int>> GetCountries();
    IEnumerable<EnumDto<int>> GetGenres();
    IEnumerable<EnumDto<int>> GetCategories();
    IEnumerable<EnumDto<int>> GetProfessions();
}