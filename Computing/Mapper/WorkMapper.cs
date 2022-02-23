using Models;
using XmlReader.BLL.DTO;

namespace XmlReader.BLL.Mapper
{
    public static class WorkMapper
    {
        public static WorkEmployeeDTO ToDTO(this WorkEmployee work)
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

        public static WorkEmployee ToEntity(this WorkEmployeeDTO work)
        {
            if (work == null)
                return null;
            return new WorkEmployee
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
                Folders = work.Folders?.Select(x => x.ToEntity()).ToList(),
            };
        }

    }
}
