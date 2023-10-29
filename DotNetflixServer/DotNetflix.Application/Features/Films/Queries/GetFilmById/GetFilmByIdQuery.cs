using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmById;

public record GetFilmByIdQuery(int FilmId, string? UserId) : IQuery<Result<MovieForMoviePageDto, string>>;
