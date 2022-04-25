using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XmlReader.BLL.Models.AuthModels;
using XmlReader.BLL.Models.Models;
using XmlReader.BLL.Service.Interfaces;

namespace XmlReader.WEB.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private byte[] salt = new byte[128/8]{ 123, 22, 44, 54,64,54,46,67,76,76,16,13,144,9,1,1 };
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public IActionResult GetRole()
    {
        if (HttpContext.User.IsInRole("user"))
        {
            return Content("user");
        }
        else if (HttpContext.User.IsInRole("admin"))
        {
            return Content("admin");
        }
        else
        {
            return new BadRequestObjectResult("Роль не найдена");
        }
    }

    [HttpPost]
    public async Task<ActionResult> LoginAsync([FromBody] LoginModel model)
    {
        model.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: model.Password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        var user = _accountService.FindAccountByLoginPasswordAsync(model);

        if (user != null)
        {
            await AuthenticateAsync(user); // аутентификация
            return Content(user.Role);
        }

        return new BadRequestObjectResult("Некорректные логин и(или) пароль");
    }

    [HttpPost]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterModel model)
    {
        var user = await _accountService.FindAccountByLoginAsync(model.Login);
        if (user == null)
        {
            model.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: model.Password, 
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256, 
                iterationCount: 100000, 
                numBytesRequested: 256 / 8));

            await _accountService.RegisterAccountAsync(model);
            var userRegistred = await _accountService.FindAccountByLoginAsync(model.Login);
            if (userRegistred != null)
            {
                await AuthenticateAsync(userRegistred); // аутентификация
                return Content( userRegistred.Role);
            }
        }
        return new BadRequestObjectResult("Такой пользователь уже существует!");
    }

    private async Task AuthenticateAsync(UserModel model)
    {
        // создаем один claim
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, model.Role),
                new Claim(ClaimTypes.NameIdentifier, model.AccountId.ToString())
            };
        // создаем объект ClaimsIdentity
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", 
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        var props = new AuthenticationProperties();
        props.IsPersistent = model.RememberMe;

        // установка аутентификационных куки
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), props);
    }

    [HttpGet]
    public async Task<IActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Content("logout");
    }
}