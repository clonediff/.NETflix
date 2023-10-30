using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Persons.Queries.GetAll;

public record GetAllPersonsQuery() : IQuery<IEnumerable<PersonDto>>;