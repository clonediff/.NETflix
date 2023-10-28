using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Features.Persons.Shared;

namespace DotNetflix.Admin.Application.Features.Persons.Queries.GetAll;

public record GetAllPersonsQuery() : IQuery<IEnumerable<PersonDto>>;