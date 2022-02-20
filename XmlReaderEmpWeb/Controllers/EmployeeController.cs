using DBRepository;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace XmlReaderEmpWeb.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IDbContextFactory<RepositoryContext> _contextFactory;
        //IEmployeeRepository _employeeRepository;

        public EmployeeController(IDbContextFactory<RepositoryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        [Route("get/all")]
        public IEnumerable<Employee> Get()
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());
            return _employeeRepository.Get();
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());
            Employee emp = await _employeeRepository.Get(Id);

            if (emp == null)
            {
                return NotFound();
            }

            return new ObjectResult(emp);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Employee emp) 
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());
            if (emp == null)
            {
                return BadRequest();
            }
            await _employeeRepository.Add(emp);

            return new ObjectResult(emp);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());

            await _employeeRepository.Delete(id);

            return new ObjectResult(id);
        }

        [HttpPut]
        [Route("change/{id}")]
        public async Task<IActionResult> Change(int id, [FromBody] Employee emp)
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());
            if (emp == null)
            {
                return BadRequest();
            }
            await _employeeRepository.ChangeAsync(id, emp);

            return new ObjectResult(emp);
        }

    }
}
