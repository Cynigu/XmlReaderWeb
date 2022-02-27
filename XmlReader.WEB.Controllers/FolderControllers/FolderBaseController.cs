using Microsoft.AspNetCore.Mvc;
using XmlReader.BLL.Mapper.ToModel;
using XmlReader.BLL.Services.FolderServices;
using XmlReader.WEB.Models;

namespace XmlReader.WEB.Controllers.FolderControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FolderBaseController : Controller
    {
        private readonly IFolderBaseService _folderBaseService;

        public FolderBaseController(IFolderBaseService empService)
        {
            this._folderBaseService = empService;
        }
        // GET: api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<FolderModel>> Get()
        {
            var emps = _folderBaseService.Get();
            return emps.Select(x => x.ToModel()).ToList();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
        [HttpPost]
        public async Task<ActionResult<FolderModel>> Post([FromBody] FolderModel entity)
        {
            await _folderBaseService.Add(entity.ToDTO());
            return entity;
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
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

