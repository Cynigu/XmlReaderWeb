using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace XmlReaderEmpWeb.Server.Controllers
{
    public class FolderController : TEntityController<Folder, IFolderRepository>
    {
        public FolderController(IFolderRepository repository) : base(repository)
        {

        }
    }
}
