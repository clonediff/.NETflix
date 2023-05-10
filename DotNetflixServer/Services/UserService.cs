using System.Security.Claims;
using Contracts.Subscriptions;
using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;

namespace Services;

public class UserService : IUserService
{
    private readonly ApplicationDBContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UserService(ApplicationDBContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<string?> GetUserIdAsync(ClaimsPrincipal claimsPrincipal)
    {
        var user = await _userManager.GetUserAsync(claimsPrincipal);

        if (user == null)
            return null;
        
        return await _userManager.GetUserIdAsync(user);
    }

    public async Task<IEnumerable<int>> GetAvailableFilmIdsAsync(string? userId)
    {
        if (userId is null)
            return Enumerable.Empty<int>();

        var user = await _dbContext.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Subscriptions)
                .ThenInclude(s => s.Movies)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return user!.Subscriptions.SelectMany(s => s.Movies.Select(m => m.Id));
    }

    public IEnumerable<GetUserSubscriptionDto> GetAllUserSubscriptions(string userId)
    {
        var userSubscriptions = _dbContext.UserSubscriptions
            .Where(us => us.UserId == userId)
            .Include(s => s.Subscription);

        return userSubscriptions
            .Select(us => new GetUserSubscriptionDto(us.Subscription.Id, us.Subscription.Name, us.Subscription.Cost, us.Expires));
    }
}