using DBModels.Forms.LoginForm;
using DBModels.Forms.RegisterForm;
using DBModels.IdentityLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private SignInManager<User> _signInManager;
    private UserManager<User> _userManager;

    public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginForm form)
    {
        //Todo: тут нужно будет сделать функционал с запоминанием пользователя(через Services.AddAuthentication().AddCookie())
        var result = await _signInManager.PasswordSignInAsync(form.UserName, form.Password, form.Remember, false);
        if (result.Succeeded)
        {
            return Ok("Вы успешно вошли в аккаунт!");
        }

        return BadRequest("Неверный логин или пароль!");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok("Вы вышли из аккаунта");
        //Todo: Тут либо статус код Ok, либо правильней будет SignOut с указанием схем
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody]RegisterForm form)
    {
        if (form.Password != form.ConfirmPassword)
        {
            return BadRequest("Разные пароли!");
        }
        
        var user = new User
        {
            UserName = form.UserName,
            PasswordHash = form.Password,
            Email = form.Email,
            Birthday = form.Birthday
        };
        
        var checkExistingEmail = await _userManager.FindByEmailAsync(user.Email);
        if (checkExistingEmail != null)
        {
            return BadRequest("Пользователь с таким email-адресом уже существует!");
        }
        
        var checkingExistingUserName = await _userManager.FindByNameAsync(user.UserName);
        if (checkingExistingUserName != null)
        {
            return BadRequest("Пользователь с таким именем уже существует!");
        } 

        var creatingResult = await _userManager.CreateAsync(user,form.Password);
        if (!creatingResult.Succeeded)
        {
            return BadRequest(creatingResult.Errors);
        }

        //await _signInManager.SignInAsync(user,true);
        return Ok("Пользователь успешно зарегистрирован!");
    }
}