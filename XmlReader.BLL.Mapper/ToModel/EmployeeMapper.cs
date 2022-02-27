using XmlReader.BLL.DTO;
using XmlReader.WEB.Models;

namespace XmlReader.BLL.Mapper.ToModel
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
                IsAdmin = emp.IsAdmin,
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
