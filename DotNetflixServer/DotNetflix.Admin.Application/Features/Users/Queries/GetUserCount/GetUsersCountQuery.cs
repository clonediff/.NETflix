using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUserCount;

public record GetUsersCountQuery() : IQuery<int>;