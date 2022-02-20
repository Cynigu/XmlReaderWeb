using DBRepository;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace XmlReaderEmpWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : TEntityController<Employee, IEmployeeRepository>
    {
        public EmployeeController(IEmployeeRepository repository) : base(repository)
        {

        }
    }
}
