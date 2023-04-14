using AdminBackendAPI.Dto;
using AdminBackendAPI.Mappers;
using DataAccess;
using DataAccess.Entities.IdentityLogic;
using DtoLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services.UserService;

namespace AdminBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<int> GetUsersCount() => await _userService.GetUsersCountAsync();

        [HttpGet("[action]")]
        public IEnumerable<UserAdminDto> GetUsers([FromQuery] string? name, [FromQuery] int? page = 1) => _userService.GetUsersFiltered(page!.Value, name);

        [HttpPut("[action]")]
        public async Task<IActionResult> SetRoleAsync([FromForm] string role, [FromForm] string userId) => await _userService.SetRoleAsync(role, userId);

        [HttpPost("[action]")]
        public async Task<IActionResult> BanUserAsync([FromForm] string userId, [FromForm] int days) => await _userService.BanUserAsync(userId, days);

        [HttpPost("[action]")]
        public async Task<IActionResult> UnbanUserAsnyc(string userId) => await _userService.UnbanUserAsync(userId);
    } 
}
