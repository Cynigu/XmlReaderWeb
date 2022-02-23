using XmlReader.BLL.DTO;

namespace XmlReaderEmpWeb.Models
{
    public class EmployeeModel: IEntityModel
    {
        public int Id { get; set; } // id
        public bool IsAdmin { get; set; } = false;// роль: рабочий = 0, админ = 1
        public string Name { get; set; } // Имя работника
        public string? NumberPhone { get; set; } // номер телефона
        public ICollection<WorkEmployeeModel>? Works { get; set; }
    }
}
