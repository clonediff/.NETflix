using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;

public record GetFilmByIdQuery(int Id) : IQuery<Result<GetFilmByIdDto, string>>;