using DataAccess;
using DtoLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _dbContext;

        public UserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
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
                throw new UserNotFoundException();

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

        public async Task SetRoleAsync(string roleId, string userId)
        {
            if (await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId) == null)
                throw new RoleNotFoundException();

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new UserNotFoundException();

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
        }

        public async Task UnbanUserAsync(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new UserNotFoundException();

            user.BannedUntil = null;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
