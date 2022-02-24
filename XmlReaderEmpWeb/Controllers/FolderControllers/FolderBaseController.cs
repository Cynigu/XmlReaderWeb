using Microsoft.AspNetCore.Mvc;
using XmlReader.BLL.Interfaces;
using XmlReader.BLL.Services.FolderServices;
using XmlReaderEmpWeb.Client.Mapper;
using XmlReaderEmpWeb.Models;

namespace XmlReaderEmpWeb.Client.Controllers.FolderControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderBaseController : Controller
    {
        private readonly IFolderBaseService _folderBaseService;

        public FolderBaseController(IFolderBaseService empService)
        {
            this._folderBaseService = empService;
        }
        // GET: api/[controller]
        [HttpGet("get")]
        public ActionResult<IEnumerable<FolderModel>> Get()
        {
            var emps = _folderBaseService.Get();
            return emps.Select(x => x.ToModel()).ToList();
        }

        // GET: api/[controller]/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<FolderModel>> Get(int id)
        {
            var entity = await _folderBaseService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity.ToModel();
        }

        // PUT: api/[controller]/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FolderModel entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _folderBaseService.Update(entity.ToDTO());
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost("add")]
        public async Task<ActionResult<FolderModel>> Post([FromBody] FolderModel entity)
        {
            await _folderBaseService.Add(entity.ToDTO());
            return entity;
        }

        // DELETE: api/[controller]/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<FolderModel>> Delete(int id)
        {
            var entity = await _folderBaseService.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity.ToModel();
        }
    }
}

