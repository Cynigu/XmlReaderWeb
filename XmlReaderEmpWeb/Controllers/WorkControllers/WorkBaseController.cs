using Microsoft.AspNetCore.Mvc;
using XmlReader.BLL.Interfaces;
using XmlReaderEmpWeb.Client.Mapper;
using XmlReaderEmpWeb.Models;

namespace XmlReaderEmpWeb.Client.Controllers.WorkControllers
{
    public class WorkBaseController : Controller
    {
        private readonly IWorkBaseService _workBaseService;

        public WorkBaseController(IWorkBaseService empService)
        {
            this._workBaseService = empService;
        }
        // GET: api/[controller]
        [HttpGet("get")]
        public ActionResult<IEnumerable<WorkEmployeeModel>> Get()
        {
            var emps = _workBaseService.Get();
            return emps.Select(x => x.ToModel()).ToList();
        }

        // GET: api/[controller]/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<WorkEmployeeModel>> Get(int id)
        {
            var entity = await _workBaseService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity.ToModel();
        }

        // PUT: api/[controller]/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkEmployeeModel entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _workBaseService.Update(entity.ToDTO());
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<WorkEmployeeModel>> Post([FromBody] WorkEmployeeModel entity)
        {
            await _workBaseService.Add(entity.ToDTO());
            return entity;
        }

        // DELETE: api/[controller]/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<WorkEmployeeModel>> Delete(int id)
        {
            var entity = await _workBaseService.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity.ToModel();
        }
    }
}
