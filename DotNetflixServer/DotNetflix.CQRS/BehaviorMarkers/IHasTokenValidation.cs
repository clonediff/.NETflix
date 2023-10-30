using Domain.Entities;

namespace DotNetflix.CQRS.BehaviorMarkers;

public interface IHasTokenValidation
{
    public User User { get; }
    
    public string Key { get; }
    
    public string Token { get; }
}