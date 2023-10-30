using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Films.Queries.GetAllFilms;

public record GetAllFilmsQuery : IQuery<Dictionary<string, IEnumerable<MovieForMainPageDto>>>;
