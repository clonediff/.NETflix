using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Users;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;
using Services.Infrastructure.EmailService;

namespace DotNetflixAdminAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        
        public UserController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [HttpGet("[action]")]
        public async Task<int> GetUsersCountAsync()
        {
            return await _userService.GetUsersCountAsync();
        }

        [HttpGet("[action]")]
        public IEnumerable<EnumDto<string>> GetAllRoles()
        {
            return _userService.GetAllRoles();
        }

        [HttpGet("[action]")]
        public async Task<PaginationDataDto<UserDto>> GetUsers([FromQuery] string? name, [FromQuery] int? page = 1)
        { 
            return await _userService.GetUsersFilteredAsync(page!.Value, name);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SetRoleAsync([FromBody] SetRoleDto setRoleDto)
        {
            try
            {
                var newRole = await _userService.SetRoleAsync(setRoleDto);
                var email = await _userService.GetEmailAsync(setRoleDto.UserId);
                await _emailService.SendEmailAsync(email, "Ваша роль обновлена", $"Теперь Вы {newRole}.");
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (IncorrectOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> BanUserAsync([FromBody] BanUserDto banUserDto)
        {
            try
            {
                var bannedUntil = await _userService.BanUserAsync(banUserDto);
                var email = await _userService.GetEmailAsync(banUserDto.UserId);
                await _emailService.SendEmailAsync(email, "Ваш аккаунт был заблокирован", $"Дата автоматической разблокировки {bannedUntil:d}.");
                return Ok(bannedUntil.ToString("d"));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (IncorrectOperationException ex)
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
                var email = await _userService.GetEmailAsync(userId);
                await _emailService.SendEmailAsync(email, "Ваш аккаунт был разблокирован", "Желаем приятно провести время на нашем сервисе");
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (IncorrectOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    } 
}
