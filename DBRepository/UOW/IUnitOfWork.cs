using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.UOW
{
    public interface IUnitOfWork
    {
        IUserProfileRepository UserProfileRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IFolderRepository FolderRepository { get; }
        IAuthUserRepository AuthUserRepository { get; }
    }
}
