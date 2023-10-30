using DataAccess;
using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetAllRoles;

internal class GetAllRolesQueryHandler : IQueryHandler<GetAllRolesQuery,IEnumerable<EnumDto<string>>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllRolesQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<EnumDto<string>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles.AsNoTracking()
            .Select(r => new EnumDto<string>(r.Id, r.Name!))
            .ToListAsync(cancellationToken);
    }
}