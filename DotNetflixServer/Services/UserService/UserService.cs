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

        public async Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _userManager.GetUserAsync(claimsPrincipal);
        }

        public async Task<string> GetEmailAsync(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new NotFoundException("Не удалось найти пользователя");
            
            return user.Email;
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

        public async Task<int> GetUsersCountAsync()
        {
            return await _dbContext.Users.CountAsync();
        }

        public IEnumerable<UserAdminDto> GetUsersFiltered(int page, string? name)
        {
            return
                (
                    from user in _dbContext.Users
                        .Where(x => name == null || x.UserName.Contains(name))
                        .Skip(25 * (page - 1))
                        .Take(25)
                    join role in _dbContext.UserRoles on user.Id equals role.UserId
                    select new UserAdminDto
                    {
                        Id = user.Id,
                        Name = user.UserName,
                        BannedUntil = user.BannedUntil,
                        RoleId = role.RoleId,
                    }
                ).AsEnumerable();
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
