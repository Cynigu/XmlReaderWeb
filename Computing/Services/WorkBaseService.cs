using DBRepository.Factories;
using DBRepository.UOW;
using Models;
using XmlReader.BLL.DTO;
using XmlReader.BLL.Interfaces;
using XmlReader.BLL.Mapper.ToEntity;

namespace XmlReader.BLL.Services
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
                await uow.WorkRepository.Add(item.ToEntity());
            }
        }

        public async Task<WorkEmployeeDTO> Delete(int id)
        {
            WorkEmployee emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = await uow.WorkRepository.Delete(id);
            }
            return emp.ToDTO();

        }

        public IEnumerable<WorkEmployeeDTO> Get()
        {
            IEnumerable<WorkEmployee> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = uow.WorkRepository.Get().ToList();
            }
            return emp.Select(x => x.ToDTO());
        }

        public async Task<WorkEmployeeDTO> Get(int id)
        {
            WorkEmployee emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = await uow.WorkRepository.Get(id);
            }
            return emp.ToDTO();
        }

        public async Task<IEnumerable<WorkEmployeeDTO>> Get(int[] ids)
        {
            IEnumerable<WorkEmployee> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = await uow.WorkRepository.Get(ids);
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
                await uow.WorkRepository.Update(item.ToEntity());
            }
        }
    }
}
