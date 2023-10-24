namespace DotNetflix.Abstractions.Cqrs;

public interface IHasCodeValidation
{
    public string Key { get; }
    
    public string Code { get; }
}