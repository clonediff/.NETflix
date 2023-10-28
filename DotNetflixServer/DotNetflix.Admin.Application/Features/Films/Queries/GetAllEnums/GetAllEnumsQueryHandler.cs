using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetAllEnums;

public class GetAllEnumsQueryHandler
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
        var getTypesTask = _dbContext.Types.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getCountriesTask = _dbContext.Countries.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getGenresTask = _dbContext.Genres.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getCategoriesTask = _dbContext.Categories.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        var getProfessionsTask = _dbContext.Professions.AsNoTracking()
            .Select(x => new EnumDto<int>(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        return new Dictionary<string, IEnumerable<EnumDto<int>>>
        {
            ["types"] = await getTypesTask,
            ["countries"] = await getCountriesTask,
            ["genres"] = await getGenresTask,
            ["categories"] = await getCategoriesTask,
            ["professions"] = await getProfessionsTask
        };
    }
}