using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;

public record GetFilmDetailsQuery(int Id) : IQuery<Result<GetFilmDetailsDto, string>>;