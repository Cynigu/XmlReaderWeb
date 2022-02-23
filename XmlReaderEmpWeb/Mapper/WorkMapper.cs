using XmlReader.BLL.DTO;
using XmlReaderEmpWeb.Models;

namespace XmlReaderEmpWeb.Client.Mapper
{
    public static class WorkMapper
    {
        public static WorkEmployeeDTO ToDTO(this WorkEmployeeModel work)
        {
            if (work == null)
                return null;
            return new WorkEmployeeDTO
            {
                Id = work.Id,
                Description = work.Description,
                BetForObject = work.BetForObject,
                CountFactFiles = work.CountFactFiles,
                CountFactObject = work.CountFactObject,
                CountPlanFiles = work.CountPlanFiles,
                DateStart = work.DateStart,
                DateEnd = work.DateEnd,
                SalaryPaid = work.SalaryPaid,
                IsGetSalary = work.IsGetSalary,
                IsEnd = work.IsEnd,
                Folders = work.Folders?.Select(x => x.ToDTO()).ToList(),
            };
        }

        public static WorkEmployeeModel ToModel(this WorkEmployeeDTO work)
        {
            if (work == null)
                return null;
            return new WorkEmployeeModel
            {
                Id = work.Id,
                Description = work.Description,
                BetForObject = work.BetForObject,
                CountFactFiles = work.CountFactFiles,
                CountFactObject = work.CountFactObject,
                CountPlanFiles = work.CountPlanFiles,
                DateStart = work.DateStart,
                DateEnd = work.DateEnd,
                SalaryPaid = work.SalaryPaid,
                IsGetSalary = work.IsGetSalary,
                IsEnd = work.IsEnd,
                Folders = work.Folders?.Select(x => x.ToModel()).ToList(),
            };
        }
    }
}
