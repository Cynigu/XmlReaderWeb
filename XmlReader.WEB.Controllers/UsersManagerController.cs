using Microsoft.AspNetCore.Mvc;

namespace XmlReader.WEB.Controllers;

public class UsersManagerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}