using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace XmlReaderEmpWeb.Server.Controllers
{
    public class WorkController : TEntityController<WorkEmployee, IWorkRepository>
    {
        public WorkController(IWorkRepository repository) : base(repository)
        {

        }
    }
}
