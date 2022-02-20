
using Models;

namespace DBRepository.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> Get(); // получение всех объектов
        Task<T> Get(int id); // получение одного объекта по id
        Task<IEnumerable<T>> Get(int[] ids); // получение одного объекта по id
        Task Add(T item); // добавление объекта
        Task Update(T item); // обновление объекта
        Task<T> Delete(int id); // удаление объекта по id
        Task SaveAsync();  // сохранение изменений
    }
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task ChangeAsync(int id, Employee item);

    }
    public interface IWorkRepository : IRepository<WorkEmployee>
    {
        Task ChangeAsync(int id, WorkEmployee item);
    }
    public interface IFolderRepository : IRepository<Folder>
    {
        Task ChangeAsync(int id , Folder item);
    }
}
