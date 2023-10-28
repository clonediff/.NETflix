using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Enums.GetAllEnums;

public record GetAllEnumsQuery() : IQuery<IDictionary<string, IEnumerable<EnumDto<int>>>>;