using Domain.Entities;
using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Enums.Queries.GetAllEnums;

internal class GetAllEnumsQueryHandler
    : IQueryHandler<GetAllEnumsQuery, IDictionary<string, IEnumerable<EnumDto<int>>>>
{
    private readonly DbContext _dbContext;

    public GetAllEnumsQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IDictionary<string, IEnumerable<EnumDto<int>>>> Handle(
        GetAllEnumsQuery request,
        CancellationToken cancellationToken)
    {
        var getTypes = await _dbContext.Set<Types>().AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getCountries = await _dbContext.Set<Country>().AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getGenres = await _dbContext.Set<Genre>().AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getCategories = await _dbContext.Set<Category>().AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getProfessions = await _dbContext.Set<Profession>().AsNoTracking()
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