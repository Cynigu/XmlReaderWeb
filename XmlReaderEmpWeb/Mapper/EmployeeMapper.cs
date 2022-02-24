using XmlReader.BLL.DTO;
using XmlReaderEmpWeb.Models;

namespace XmlReaderEmpWeb.Client.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeModel ToModel(this EmployeeDTO emp)
        {
            if (emp == null)
                return null;
            return new EmployeeModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Works = emp.Works?.Select(x => x.ToModel()).ToList(),
                NumberPhone = emp.NumberPhone,
                IsAdmin = emp.IsAdmin
                Email = emp.Email,
                Vk = emp.Vk,
            };
        }
        public static EmployeeDTO ToDTO(this EmployeeModel emp)
        {
            if (emp == null)
                return null;
            return new EmployeeDTO
            {
                Id = emp.Id,
                Name = emp.Name,
                Works = emp.Works?.Select(x => x.ToDTO()).ToList(),
                NumberPhone = emp.NumberPhone,
                IsAdmin = emp.IsAdmin,
                Email = emp.Email,
                Vk = emp.Vk,
            };
        }
    }
}
