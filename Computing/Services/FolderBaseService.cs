using DBRepository.Factories;
using Models;
using XmlReader.BLL.DTO;
using XmlReader.BLL.Mapper.ToEntity;
using XmlReader.BLL.Services.FolderServices;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class FolderBaseService : IFolderBaseService
    {
        private readonly IRepositoryContextFactory _contextFactory;
        public FolderBaseService(IRepositoryContextFactory repositoryContextFactory)
        {
            _contextFactory = repositoryContextFactory;
        }

        public async Task Add(FolderDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.FolderRepository.AddRangeAsync(new List<FolderEntity>(){ item.ToEntity()});
            }
        }

        public async Task<FolderDTO> Delete(int id)
        {
            FolderEntity emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = (await uow.FolderRepository.RemoveRangeAsync(x => x.Id == id)).First();
            }
            return emp.ToDTO();

        }

        public IEnumerable<FolderDTO> Get()
        {
            IEnumerable<FolderEntity> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = uow.FolderRepository.GetEntityQuery().ToList();
            }
            return emp.Select(x => x.ToDTO());
        }

        public async Task<FolderDTO> Get(int id)
        {
            FolderEntity? emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                IQueryable<FolderEntity?> emps = uow.FolderRepository.GetEntityQuery();
                emp = emps.FirstOrDefault(x => x != null && x.Id == id);
            }
            return emp.ToDTO();
        }

        public async Task<IEnumerable<FolderDTO>> Get(int[] ids)
        {
            IQueryable<FolderEntity?> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                IQueryable<FolderEntity?> emps = uow.FolderRepository.GetEntityQuery();
                emp = emps.Where(x => x != null && ids.Contains(x.Id));
            }
            return emp.Select(x => x.ToDTO());
        }

        public async Task SaveAsync()
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.SaveAsync();
            }
        }

        public async Task Update(FolderDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.FolderRepository.UpdateAsync(item.ToEntity());
            }
        }
    }
}
