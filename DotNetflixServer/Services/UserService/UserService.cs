using DataAccess;
using DtoLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Services.UserService
{
    public class UserService : IUserService
    {

        readonly ApplicationDBContext _dbContext;

        public UserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> BanUserAsync(string userId, int days)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return new NotFoundObjectResult("No user with this id");

            user.BannedUntil = DateTime.Now.Add(TimeSpan.FromDays(days));
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new 
            {
               BannedUntil = user.BannedUntil,
            });
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await _dbContext.Users.CountAsync();
        }

        public IEnumerable<UserAdminDto> GetUsersFiltered(int page, string? name)
        {
            return
                (from user in _dbContext.Users.Where(x => name == null || x.UserName.Contains(name)).Skip(25 * (page - 1)).Take(25)
                 join role in _dbContext.UserRoles on user.Id equals role.UserId
                 select new UserAdminDto
                 {
                     Id = user.Id,
                     UserName = user.UserName,
                     BannedUntil = user.BannedUntil,
                     RoleId = role.RoleId,
                 }).AsEnumerable();
        }

        public async Task<IActionResult> SetRoleAsync(string role, string userId)
        {
            if (_dbContext.Roles.FirstOrDefault(r => r.Id == role) == null)
                return new BadRequestObjectResult("Wrong role");

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return new NotFoundObjectResult("No user with this id");

            var userRoles = _dbContext.UserRoles.Where(x => x.UserId == userId).AsEnumerable();
            _dbContext.UserRoles.RemoveRange(userRoles);

            await _dbContext.UserRoles.AddAsync(new IdentityUserRole<string> 
            { 
                RoleId = role,
                UserId = userId,
            });

            await _dbContext.SaveChangesAsync();

            return new OkObjectResult("Role set");
        }

        public async Task<IActionResult> UnbanUserAsync(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return new NotFoundObjectResult("No user with this id");

            user.BannedUntil = null;
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult("Unbanned");
        }
    }
}
