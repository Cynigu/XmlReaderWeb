using Models;

namespace DBRepository.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> Get(); // получение всех объектов
        Task<T> Get(int id); // получение одного объекта по id
        Task<IEnumerable<T>> Get(int[] ids); // получение одного объекта по id
        Task CreateAsync(T item); // создание объекта
        void Update(T item); // обновление объекта
        Task DeleteAsync(int id); // удаление объекта по id
        Task SaveAsync();  // сохранение изменений
    }
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }
    public interface IWorkRepository : IRepository<WorkEmployee>
    {

    }
    public interface IFolderRepository : IRepository<Folder>
    {

    }
}
