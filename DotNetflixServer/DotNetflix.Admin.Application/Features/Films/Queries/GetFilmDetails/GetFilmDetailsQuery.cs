using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;

public record GetFilmDetailsQuery(int Id) : IQuery<Result<GetFilmDetailsDto, string>>;