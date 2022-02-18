using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task CreateAsync(Employee item)
        {
            await _repositoryContext.Employees.AddAsync(item);  
        }

        public async Task DeleteAsync(int id)
        {
            Employee? emp = await _repositoryContext.Employees.FindAsync(id);
            if (emp != null)
                _repositoryContext.Employees.Remove(emp);
        }

        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> result;

            result = _repositoryContext.Employees;
            
            return result;
        }

        public async Task<Employee> Get(int id)
        {
            Employee? result;
            result = await _repositoryContext.Employees.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Employee>> Get(int[] ids)
        {
            List<Employee> result = new List<Employee>();


            foreach (var id in ids)
            {
                var emp = await _repositoryContext.Employees.FindAsync(id);
                if(emp != null)
                    result.Add(emp);
            }
            
            
            return result;
        }

        public async Task SaveAsync()
        {
            
            await _repositoryContext.SaveChangesAsync();
            
        }

        public void Update(Employee item)
        {
            
            _repositoryContext.Entry(item).State = EntityState.Modified;
            
        }
    }
}
