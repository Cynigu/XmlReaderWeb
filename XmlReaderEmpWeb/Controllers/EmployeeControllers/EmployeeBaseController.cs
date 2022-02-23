using Microsoft.AspNetCore.Mvc;
using XmlReader.BLL.Interfaces;
using XmlReaderEmpWeb.Client.Mapper;
using XmlReaderEmpWeb.Models;

namespace XmlReaderEmpWeb.Client.Controllers.EmployeeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBaseController: Controller
    {
        private readonly IEmployeeBaseService _employeeBaseService;

        public EmployeeBaseController(IEmployeeBaseService empService)
        {
            this._employeeBaseService = empService;
        }
        // GET: api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> Get()
        {
            var emps = _employeeBaseService.Get();
            return emps.Select(x => x.ToModel()).ToList();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> Get(int id)
        {
            var entity = await _employeeBaseService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity.ToModel() ;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _employeeBaseService.Update(entity.ToDTO());
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> Post([FromBody] EmployeeModel entity)
        {
            await _employeeBaseService.Add(entity.ToDTO());
            return entity;
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeModel>> Delete(int id)
        {
            var entity = await _employeeBaseService.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity.ToModel();
        }
    }
}
