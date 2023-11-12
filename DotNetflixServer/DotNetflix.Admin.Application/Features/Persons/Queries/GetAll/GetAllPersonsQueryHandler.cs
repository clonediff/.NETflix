using Domain.Entities;
using DotNetflix.Admin.Application.Features.Persons.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Persons.Queries.GetAll;

internal class GetAllPersonsQueryHandler : IQueryHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
{
    private readonly DbContext _dbContext;

    public GetAllPersonsQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PersonDto>> Handle(
        GetAllPersonsQuery request,
        CancellationToken cancellationToken)
    {
        //TODO: сваггер умирает в случае, если тут DbContext
        return await _dbContext.Set<Person>().AsNoTracking()
            .Select(p => p.ToPersonsDto())
            .ToListAsync(cancellationToken);
    }
}