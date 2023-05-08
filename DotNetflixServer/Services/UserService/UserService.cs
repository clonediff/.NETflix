using System.Security.Claims;
using DataAccess;
using DataAccess.Entities.IdentityLogic;
using DtoLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserService(ApplicationDBContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await _dbContext.Users.CountAsync();
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

        public async Task<string> GetEmailAsync(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new NotFoundException("Не удалось найти пользователя");
            
            return user.Email;
        }

        public IEnumerable<GetUserSubscriptionDto> GetAllUserSubscriptions(string userId)
        {
            var userSubscriptions = _dbContext.UserSubscriptions
                .Where(us => us.UserId == userId)
                .Include(s => s.Subscription);

            return userSubscriptions.Select(us => new GetUserSubscriptionDto
            {
                Id = us.Subscription.Id,
                Expires = us.Expires,
                Cost = us.Subscription.Cost,
                SubscriptionName = us.Subscription.Name
            });
        }

        public IEnumerable<GetRoleDto> GetAllRoles()
        {
            return _dbContext.Roles
                .Select(x => new GetRoleDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .AsEnumerable();
        }

        public async Task<DateTime> BanUserAsync(string userId, int days)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new NotFoundException("Не удалось найти пользователя");

            if (user.BannedUntil != null)
                throw new IncorrectOperationException("Нельзя заблокировать уже заблокированного пользователя");

            user.BannedUntil = DateTime.Now.Add(TimeSpan.FromDays(days));
            
            await _dbContext.SaveChangesAsync();

            return user.BannedUntil.Value;
        }

        public async Task<PaginationDataDto<UserAdminDto>> GetUsersFilteredAsync(int page, string? name)
        {
            var filteredUsers = _dbContext.Users
                .Where(x => name == null || x.UserName.Contains(name));

            var filteredUsersCount = await filteredUsers.CountAsync();

            var users = filteredUsers
                .Join(
                    _dbContext.UserRoles,
                    user => user.Id,
                    role => role.UserId,
                    (user, role) => new UserAdminDto
                    {
                        Id = user.Id,
                        Name = user.UserName,
                        BannedUntil = user.BannedUntil,
                        RoleId = role.RoleId
                    })
                .AsEnumerable();

            return new PaginationDataDto<UserAdminDto>
            {
                Data = users,
                Count = filteredUsersCount
            };
        }

        public async Task<string> SetRoleAsync(string roleId, string userId)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            
            if (role == null)
                throw new NotFoundException("Не удалось найти роль");

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new NotFoundException("Не удалось найти пользователя");

            if (user.BannedUntil != null)
                throw new IncorrectOperationException("Нельзя менять роль заблокированным пользователям");

            var userRoles = _dbContext.UserRoles
                .Where(x => x.UserId == userId)
                .AsEnumerable();
            
            _dbContext.UserRoles.RemoveRange(userRoles);

            await _dbContext.UserRoles.AddAsync(new IdentityUserRole<string> 
            { 
                RoleId = roleId,
                UserId = userId,
            });

            await _dbContext.SaveChangesAsync();

            return role.Name!;
        }

        public async Task UnbanUserAsync(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new NotFoundException("Не удалось найти пользователя");

            if (user.BannedUntil == null)
                throw new IncorrectOperationException("Нельзя разблокировать уже разблокированного пользователя");

            user.BannedUntil = null;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
