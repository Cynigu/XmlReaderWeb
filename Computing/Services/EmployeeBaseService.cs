using DBRepository.Factories;
using Models;
using XmlReader.BLL.DTO;
using XmlReader.BLL.Interfaces;
using XmlReader.BLL.Mapper.ToEntity;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class EmployeeBaseService : IEmployeeBaseService
    {
        private readonly IRepositoryContextFactory _contextFactory;
        public EmployeeBaseService(IRepositoryContextFactory repositoryContextFactory)
        {
            _contextFactory = repositoryContextFactory;
        }

        public async Task Add(EmployeeDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.EmployeeRepository.AddRangeAsync(new List<Employee>(){item.ToEntity()});
            }
        }

        public async Task<EmployeeDTO> Delete(int id)
        {
            Employee emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = (await uow.EmployeeRepository.RemoveRangeAsync(x=> x.Id == id)).First();
            }
            return emp.ToDTO();

        }

        public IEnumerable<EmployeeDTO> Get()
        {
            IEnumerable<Employee> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = uow.EmployeeRepository.GetEntityQuery().ToList();
            }
            return emp.Select(x=>x.ToDTO());
        }

        public async Task<EmployeeDTO> Get(int id)
        {
            Employee? emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                IQueryable<Employee?> emps = uow.EmployeeRepository.GetEntityQuery();
                emp = emps.FirstOrDefault(x => x != null && x.Id == id);
            }
            return emp.ToDTO();
        }

        public async Task<IEnumerable<EmployeeDTO>> Get(int[] ids)
        {
            IQueryable<Employee?> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                IQueryable<Employee?> emps = uow.EmployeeRepository.GetEntityQuery();
                emp = emps.Where(x => x!=null && ids.Contains(x.Id));
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

        public async Task Update(EmployeeDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.EmployeeRepository.UpdateAsync(item.ToEntity());
            }
        }
    }
}
