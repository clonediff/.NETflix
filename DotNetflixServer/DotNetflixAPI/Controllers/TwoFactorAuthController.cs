using Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class TwoFactorAuthController : Controller
	{
		private readonly ITwoFAService _twoFAService;
		private readonly UserManager<User> _userManager;

		public TwoFactorAuthController(UserManager<User> userManager, ITwoFAService twoFAService)
		{
			_userManager = userManager;
			_twoFAService = twoFAService;
		}

		[HttpGet("[action]")]
		public async Task SendCodeAsync()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			await _twoFAService.SendCodeAsync(user.Email);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> EnableAsync([FromBody] TwoFADto twoFA)
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (!_twoFAService.CheckCode(user.Email, twoFA.Code))
				return BadRequest("Код не совпадает или устарел");
			var enableResult = await _userManager.SetTwoFactorEnabledAsync(user, true);
			if (!enableResult.Succeeded)
				return BadRequest(enableResult.Errors);
			return Ok("Двухфакторная аутентификация подключена");
		}
	}
}
