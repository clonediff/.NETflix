using System.Security.Claims;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.User.Queries.GetUserId;

public record GetUserIdQuery(ClaimsPrincipal ClaimsPrincipal) : IQuery<string?>;
