using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Enums.Queries.GetAllEnums;

internal class GetAllEnumsQueryHandler
    : IQueryHandler<GetAllEnumsQuery, IDictionary<string, IEnumerable<EnumDto<int>>>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllEnumsQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IDictionary<string, IEnumerable<EnumDto<int>>>> Handle(
        GetAllEnumsQuery request,
        CancellationToken cancellationToken)
    {
        var getTypes = await _dbContext.Types.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getCountries = await _dbContext.Countries.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getGenres = await _dbContext.Genres.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getCategories = await _dbContext.Categories.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getProfessions = await _dbContext.Professions.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        return new Dictionary<string, IEnumerable<EnumDto<int>>>
        {
            ["types"] =  getTypes,
            ["countries"] =  getCountries,
            ["genres"] =  getGenres,
            ["categories"] =  getCategories,
            ["professions"] =  getProfessions
        };
    }
}