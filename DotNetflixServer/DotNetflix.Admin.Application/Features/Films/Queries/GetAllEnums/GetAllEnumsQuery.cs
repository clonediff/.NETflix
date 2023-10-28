using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetAllEnums;

public record GetAllEnumsQuery() : IQuery<IDictionary<string, IEnumerable<EnumDto<int>>>>;