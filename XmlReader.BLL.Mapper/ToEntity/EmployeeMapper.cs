using Models;
using XmlReader.BLL.DTO;

namespace XmlReader.BLL.Mapper.ToEntity
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO ToDTO(this Employee? emp)
        {
            if (emp == null)
                return null;
            return new EmployeeDTO
            {
                Id = emp.Id,
                Name = emp.Name,
                Works = emp.Works?.Select(x=>x.ToDTO()).ToList(),
                NumberPhone = emp.NumberPhone,
                IsAdmin = emp.IsAdmin,
                Email = emp.Email,
                Vk = emp.Vk,
            };
        }

        public static Employee ToEntity(this EmployeeDTO emp)
        {
            if (emp == null)
                return null;
            return new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Works = emp.Works?.Select(x => x.ToEntity()).ToList(),
                NumberPhone = emp.NumberPhone,
                IsAdmin = emp.IsAdmin,
                Email = emp.Email,
                Vk = emp.Vk,
            };
        }
    }
}
