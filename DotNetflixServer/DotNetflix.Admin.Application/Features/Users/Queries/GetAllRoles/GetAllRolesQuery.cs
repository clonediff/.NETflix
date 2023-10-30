using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetAllRoles;

public record GetAllRolesQuery() : IQuery<IEnumerable<EnumDto<string>>>;
