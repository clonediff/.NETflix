using AdminBackendAPI.Dto;
using DataAccess;
using DtoLibrary;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.MailSenderService;
using Services.UserService;

namespace AdminBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IEnumerable<GetRoleDto> GetAllRoles()
        {
            return _userService.GetAllRoles();
        }

        [HttpGet("[action]")]
        public async Task<PaginationDataDto<UserAdminDto>> GetUsers([FromQuery] string? name, [FromQuery] int? page = 1)
        { 
            return await _userService.GetUsersFilteredAsync(page!.Value, name);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SetRoleAsync([FromBody] SetRoleDto setRoleDto)
        {
            try
            {
                var newRole = await _userService.SetRoleAsync(setRoleDto.RoleId, setRoleDto.UserId);
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
                var bannedUntil = await _userService.BanUserAsync(banUserDto.UserId, banUserDto.Days);
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
                await _emailService.SendEmailAsync(email, "Ваш аккаунт был разблокирован",
                    "Желаем приятно провести время на нашем сервисе");
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
