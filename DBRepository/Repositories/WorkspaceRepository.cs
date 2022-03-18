using DBRepository;
using Models;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories;

public class WorkspaceRepository : DataBaseRepository<WorkspaceEntity, RepositoryContext>, IWorkspaceRepository
{
    public WorkspaceRepository(RepositoryContext context) : base(context)
    {
    }

}