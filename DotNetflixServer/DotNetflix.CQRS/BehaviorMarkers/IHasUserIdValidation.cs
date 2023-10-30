namespace DotNetflix.CQRS.BehaviorMarkers;

public interface IHasUserIdValidation
{
    public string UserId { get; init; }
}