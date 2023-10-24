using Contracts.Shared;

namespace DotNetflix.Abstractions.Cqrs;

public interface IHasCardValidation
{
    CardDataDto CardDataDto { get; }
}
