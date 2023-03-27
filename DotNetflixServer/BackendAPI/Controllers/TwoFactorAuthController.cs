using BackendAPI.Dto;
using DBModels.IdentityLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.TwoFAService;
using Services.MailSenderService;

namespace BackendAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TwoFactorAuthController : Controller
	{
		private ITwoFAService _twoFAService;
		private UserManager<User> _userManager;

		public TwoFactorAuthController(UserManager<User> userManager, ITwoFAService twoFAService)
		{
			_userManager = userManager;
			_twoFAService = twoFAService;
		}

		[HttpGet("[action]")]
		public async Task SendCodeAsync()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			await _twoFAService.SendCodeAsync(user);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> EnableAsync([FromBody]TwoFADto twoFA)
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (!_twoFAService.CheckCode(user, twoFA.Code))
				return BadRequest("Код не совпадает или устарел");
			var enableResult = await _userManager.SetTwoFactorEnabledAsync(user, true);
			if (!enableResult.Succeeded)
				return BadRequest(enableResult.Errors);
			return Ok("Двухфакторная аутентификация подключена");
		}
	}
}
