using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XmlReader.BLL.DTO;
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
            return new BadRequestObjectResult( new {Message = "Аккаунт не найден"});
        }
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ICollection<UserInfo>> GetUsersInfosByFilterAsync([FromBody] Filter filter)
    {

        var users = await _userProfileService.GetUsersInfosByLoginAsync(filter.SearchStr);
        return users;

    }
}