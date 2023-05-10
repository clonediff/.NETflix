using Contracts.Admin.DataRepresentation;
using DataAccess;
using Services.Admin.Abstractions;

namespace Services.Admin;

public class EnumService : IEnumService
{
    private readonly ApplicationDBContext _dbContext;

    public EnumService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IDictionary<string, IEnumerable<EnumDto<int>>> GetAll()
    {
        return new Dictionary<string, IEnumerable<EnumDto<int>>>
        {
            ["types"] = GetTypes(),
            ["countries"] = GetCountries(),
            ["genres"] = GetGenres(),
            ["categories"] = GetCategories(),
            ["professions"] = GetProfessions()
        };
    }

    public IEnumerable<EnumDto<int>> GetTypes()
    {
        return _dbContext.Types.Select(x => new EnumDto<int>(x.Id, x.Name));
    }

    public IEnumerable<EnumDto<int>> GetCountries()
    {
        return _dbContext.Countries.Select(x => new EnumDto<int>(x.Id, x.Name));
    }

    public IEnumerable<EnumDto<int>> GetGenres()
    {
        return _dbContext.Genres.Select(x => new EnumDto<int>(x.Id, x.Name));
    }

    public IEnumerable<EnumDto<int>> GetCategories()
    {        
        return _dbContext.Categories.Select(x => new EnumDto<int>(x.Id, x.Name));
    }

    public IEnumerable<EnumDto<int>> GetProfessions()
    {
        return _dbContext.Professions.Select(x => new EnumDto<int>(x.Id, x.Name));
    }
}