using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlReader.BLL.DTO;
using XmlReaderEmpWeb.Models;

namespace XmlReader.BLL.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO ToDTO(this Employee emp)
        {
            if (emp == null)
                return null;
            return new EmployeeDTO
            {
                Id = emp.Id,
                Name = emp.Name,
                Works = emp.Works?.Select(x=>x.ToDTO()).ToList(),
                NumberPhone = emp.NumberPhone,
                IsAdmin = emp.IsAdmin
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
                IsAdmin = emp.IsAdmin
            };
        }

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
            };
        }
    }
}
