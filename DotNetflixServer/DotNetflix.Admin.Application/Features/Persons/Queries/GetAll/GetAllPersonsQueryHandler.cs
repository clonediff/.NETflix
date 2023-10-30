using DataAccess;
using DotNetflix.Admin.Application.Features.Persons.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Persons.Queries.GetAll;

internal class GetAllPersonsQueryHandler : IQueryHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllPersonsQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PersonDto>> Handle(
        GetAllPersonsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Persons.AsNoTracking()
            .Select(p => p.ToPersonsDto())
            .ToListAsync(cancellationToken);
    }
}