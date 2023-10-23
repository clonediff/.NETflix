using System.Security.Claims;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Shared;

namespace DotNetflix.Application.Features.Users.Queries.GetUser;

public record GetUserQuery(ClaimsPrincipal User) : IQuery<UserDto>;
