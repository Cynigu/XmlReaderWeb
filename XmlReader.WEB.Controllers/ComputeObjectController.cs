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
    public ActionResult<FolderInfo> GetFolderInfoXml([FromBody] FolderInfo folderInfo)
    {
        if (string.IsNullOrEmpty(folderInfo.FolderPath))
        {
            return folderInfo;
        }
        var folderComputedInfo = _computeObjectXmlService.GetFolderInfoXml(folderInfo.FolderPath, folderInfo.Bet);
        return folderComputedInfo;
    }

}