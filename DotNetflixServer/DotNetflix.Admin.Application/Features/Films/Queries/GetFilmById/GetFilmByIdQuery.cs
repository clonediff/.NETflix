using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;

public record GetFilmByIdQuery(int Id) : IQuery<Result<GetFilmByIdDto, string>>;