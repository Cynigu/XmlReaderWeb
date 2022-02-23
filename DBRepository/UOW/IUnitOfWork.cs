using DBRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.UOW
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IWorkRepository WorkRepository { get; }
        IFolderRepository FolderRepository { get; }
        IAuthUserRepository AuthUserRepository { get; }
    }
}
