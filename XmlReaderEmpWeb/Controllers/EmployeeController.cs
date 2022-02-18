using DBRepository;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Http;
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
        [Route("getAll")]
        public IEnumerable<Employee> Get()
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());
            return _employeeRepository.Get();
        }
        [HttpGet]
        [Route("getById")]
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
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Employee emp) 
        {
            IEmployeeRepository _employeeRepository = new EmployeeRepository(_contextFactory.CreateDbContext());
            if (emp == null)
            {
                return BadRequest();
            }
            _employeeRepository.CreateAsync(emp);

            return CreatedAtRoute("getById", new { id = emp.Id }, emp);
        }
    }
}
