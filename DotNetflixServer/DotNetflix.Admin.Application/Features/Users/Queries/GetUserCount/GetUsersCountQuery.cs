using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUserCount;

public record GetUsersCountQuery() : IQuery<int>;