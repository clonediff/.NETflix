using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsCount;

public record GetFilmsCountQuery : IQuery<int>;