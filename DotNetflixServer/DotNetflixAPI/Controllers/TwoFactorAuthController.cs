using Domain.Entities;
using DotNetflix.Application.Features.TwoFactorAuthorization.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Infrastructure.EmailService;
using Services.Shared.CodeGenerator;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TwoFactorAuthController : Controller
{
	private readonly ICodeGenerator _codeGenerator;
	private readonly UserManager<User> _userManager;
	private readonly IMediator _mediator;
	private readonly IEmailService _emailService;
	private readonly IMemoryCache _memoryCache;

	public TwoFactorAuthController(ICodeGenerator codeGenerator, UserManager<User> userManager, IMediator mediator, IEmailService emailService, IMemoryCache memoryCache)
	{
		_codeGenerator = codeGenerator;
		_userManager = userManager;
		_mediator = mediator;
		_emailService = emailService;
		_memoryCache = memoryCache;
	}

	[HttpGet("[action]")]
	public async Task SendCodeAsync()
	{
		var user = await _userManager.GetUserAsync(HttpContext.User);
		var code = _codeGenerator.GenerateCode();
		await _emailService.SendEmailAsync(user!.Email!, "Код для двухфакторной аутентификации", code);
		_memoryCache.Set(user!.Email!, code, TimeSpan.FromMinutes(5));
	}

	[HttpPost("[action]")]
	public async Task<IActionResult> EnableAsync([FromBody] EnableTwoFactorAuthDto dto)
	{
		var user = await _userManager.GetUserAsync(HttpContext.User);
		var command = new EnableTwoFactorAuthCommand(user!, user!.Email!, dto.Code);
		var result = await _mediator.Send(command);

		return result.Match<IActionResult>(
			success: Ok,
			failure: BadRequest);
	}
}