using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Enums.Queries.GetAllEnums;

public record GetAllEnumsQuery() : IQuery<IDictionary<string, IEnumerable<EnumDto<int>>>>;