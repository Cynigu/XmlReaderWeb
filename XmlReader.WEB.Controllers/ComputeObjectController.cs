using Microsoft.AspNetCore.Mvc;

namespace XmlReader.WEB.Controllers;

public class ComputeObjectController : Controller
{
    // GET
    public IActionResult GetCountObject()
    {
        return View();
    }
}