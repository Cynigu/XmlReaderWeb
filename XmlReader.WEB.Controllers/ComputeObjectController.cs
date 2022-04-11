using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlReader.BLL.Models.Models;
using XmlReader.BLL.Service.Interfaces;

namespace XmlReader.WEB.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ComputeObjectController : Controller
{
    private readonly IComputeObjectXmlService _computeObjectXmlService;

    public ComputeObjectController(IComputeObjectXmlService empService)
    {
        this._computeObjectXmlService = empService;
    }

    
    [HttpPost]
    [Authorize(Roles = "user")]
    public ActionResult<int> GetCountObject(IFormFileCollection files)
    {
        if (files.Count <= 0)
        {
            return 0;
        }
        var countObject = _computeObjectXmlService.GetCountObject(files);
        return countObject;
    }
}