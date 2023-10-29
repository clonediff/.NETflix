using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetAllRoles;

public record GetAllRolesQuery() : IQuery<IEnumerable<EnumDto<string>>>;
