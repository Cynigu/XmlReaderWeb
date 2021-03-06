using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XmlReader.BLL.Models;
using XmlReader.BLL.Models.AuthModels;
using XmlReader.BLL.Models.Models;
using XmlReader.BLL.Service.Interfaces;

namespace XmlReader.WEB.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserProfileController : Controller
{
    private readonly IUserProfileService _userProfileService;
    public UserProfileController(IUserProfileService userProfileService)
    {
        _userProfileService = userProfileService;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<UserInfo> GetUserInfoForSelfAccount()
    {
        try
        {
            var userInfo = _userProfileService.GetUserInfoByLogin(login: HttpContext.User.Identity.Name);

            return userInfo;
        }
        catch
        {
            return new BadRequestObjectResult(  "Аккаунт не найден");
        }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "admin")]
    public async Task<ActionResult< ICollection<UserInfo>>> GetUsersInfosByFilterAsync([FromBody] Filter filter)
    {
        try
        {
            var users = await _userProfileService.GetUsersInfosByLoginAsync(filter.SearchStr);
            return this.Ok(users);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "admin")]
    public async Task<ActionResult> DeleteUserInfosByLoginAsync([FromBody] FilterLogin login)
    {
        try
        {
            await _userProfileService.DeleteUserByLoginAsync(login.Login);
            return this.Ok();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}