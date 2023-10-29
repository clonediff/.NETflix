namespace DotNetflix.Abstractions.Cqrs;

public interface IHasUserIdValidation
{
    public string UserId { get; init; }
}