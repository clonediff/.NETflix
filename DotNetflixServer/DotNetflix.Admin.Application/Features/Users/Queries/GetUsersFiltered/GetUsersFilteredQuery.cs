using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUsersFiltered;

public record GetUsersFilteredQuery(string? Name, int Page) : IQuery<PaginationDataDto<UserDto>>;
