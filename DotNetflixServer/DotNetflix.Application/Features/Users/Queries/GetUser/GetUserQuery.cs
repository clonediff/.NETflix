using System.Security.Claims;
using DotNetflix.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Users.Queries.GetUser;

public record GetUserQuery(ClaimsPrincipal User) : IQuery<UserDto>;
