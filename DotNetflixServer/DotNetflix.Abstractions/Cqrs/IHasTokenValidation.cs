using Domain.Entities;

namespace DotNetflix.Abstractions.Cqrs;

public interface IHasTokenValidation
{
    public User User { get; }
    
    public string Key { get; }
    
    public string Token { get; }
}