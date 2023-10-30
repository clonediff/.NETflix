using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsCount;

public record GetFilmsCountQuery : IQuery<int>;