using System.Security.Claims;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Queries.GetUserId;

public record GetUserIdQuery(ClaimsPrincipal ClaimsPrincipal) : IQuery<string?>;
