using AdminBackendAPI.Dto;
using DataAccess;
using DtoLibrary;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.UserService;

namespace AdminBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDBContext _dbContext;
        
        public UserController(IUserService userService, ApplicationDBContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public IEnumerable<GetRoleDto> GetAllRoles()
        {
            return _userService.GetAllRoles();
        }

        [HttpGet("[action]")]
        public async Task<int> GetUsersCount()
        { 
            return await _userService.GetUsersCountAsync();
        }

        [HttpGet("[action]")]
        public IEnumerable<UserAdminDto> GetUsers([FromQuery] string? name, [FromQuery] int? page = 1)
        { 
            return _userService.GetUsersFiltered(page!.Value, name);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SetRoleAsync([FromBody] SetRoleDto setRoleDto)
        {
            try
            {
                await _userService.SetRoleAsync(setRoleDto.RoleId, setRoleDto.UserId);
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RoleNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> BanUserAsync([FromBody] BanUserDto banUserDto)
        {
            try
            {
                var bannedUntil = await _userService.BanUserAsync(banUserDto.UserId, banUserDto.Days);
                return Ok(bannedUntil.ToString("d"));
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UnbanUserAsync([FromBody] string userId)
        {
            try
            {
                await _userService.UnbanUserAsync(userId);
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    } 
}
