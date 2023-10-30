using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmById;

public record GetFilmByIdQuery(int FilmId, string? UserId) : IQuery<Result<MovieForMoviePageDto, string>>;
