using Contracts.Shared;

namespace DotNetflix.CQRS.BehaviorMarkers;

public interface IHasCardValidation
{
    CardDataDto CardDataDto { get; }
}
