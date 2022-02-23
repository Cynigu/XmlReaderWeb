using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace XmlReaderEmpWeb.Server.Controllers
{
    public class WorkController : BaseMethodsController<WorkEmployee, IWorkRepository>
    {
        public WorkController(IWorkRepository repository) : base(repository)
        {

        }
    }
}
