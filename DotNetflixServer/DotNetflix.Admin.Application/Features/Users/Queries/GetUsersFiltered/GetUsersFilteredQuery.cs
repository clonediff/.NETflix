using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUsersFiltered;

public record GetUsersFilteredQuery(string? Name, int Page) : IQuery<PaginationDataDto<UserDto>>;
