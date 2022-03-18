using DBRepository.Factories;
using Models;
using XmlReader.BLL.DTO;
using XmlReader.BLL.Interfaces;
using XmlReader.BLL.Mapper.ToEntity;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class WorkBaseService: IWorkBaseService
    {
        private readonly IRepositoryContextFactory _contextFactory;
        public WorkBaseService(IRepositoryContextFactory repositoryContextFactory)
        {
            _contextFactory = repositoryContextFactory;
        }

        public async Task Add(WorkEmployeeDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.WorkRepository.AddRangeAsync(new List<ProjectEntity>(){ item.ToEntity()});
            }
        }

        public async Task<WorkEmployeeDTO> Delete(int id)
        {
            ProjectEntity emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = (await uow.WorkRepository.RemoveRangeAsync(x => x.Id == id)).First();
            }
            return emp.ToDTO();

        }

        public IEnumerable<WorkEmployeeDTO> Get()
        {
            IEnumerable<ProjectEntity> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = uow.WorkRepository.GetEntityQuery().ToList();
            }
            return emp.Select(x => x.ToDTO());
        }

        public async Task<WorkEmployeeDTO> Get(int id)
        {
            ProjectEntity? emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                IQueryable<ProjectEntity?> emps = uow.WorkRepository.GetEntityQuery();
                emp = emps.FirstOrDefault(x => x != null && x.Id == id);
            }
            return emp.ToDTO();
        }

        public async Task<IEnumerable<WorkEmployeeDTO>> Get(int[] ids)
        {
            IQueryable<ProjectEntity?> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                IQueryable<ProjectEntity?> emps = uow.WorkRepository.GetEntityQuery();
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

        public async Task Update(WorkEmployeeDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.WorkRepository.UpdateAsync(item.ToEntity());
            }
        }
    }
}
