using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.UOW
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IWorkRepository WorkRepository { get; }
        IFolderRepository FolderRepository { get; }
        IAuthUserRepository AuthUserRepository { get; }
    }
}
