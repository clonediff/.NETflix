using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;

public record GetFilmsBySearchQuery(MovieSearchDto Dto) : IQuery<IEnumerable<MovieForSearchPageDto>>;
