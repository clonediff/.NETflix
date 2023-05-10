using System.Security.Claims;
using Contracts.Subscriptions;

namespace Services.Abstractions;

public interface IUserService
{
    Task<string?> GetUserIdAsync(ClaimsPrincipal claimsPrincipal);
    Task<IEnumerable<int>> GetAvailableFilmIdsAsync(string? userId);
    IEnumerable<GetUserSubscriptionDto> GetAllUserSubscriptions(string userId);
}