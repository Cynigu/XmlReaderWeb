using XmlReader.BLL.DTO;
using XmlReader.WEB.Models;

namespace XmlReader.BLL.Mapper.ToModel
{
    public static class FolderMapper
    {
        public static FolderModel ToModel(this FolderDTO emp)
        {
            if (emp == null)
                return null;
            return new FolderModel
            {
                Id = emp.Id,
                PathFolder = emp.PathFolder,
                CountFiles = emp.CountFiles,
                CountObject = emp.CountObject,
                CountXmlFiles = emp.CountXmlFiles,
            };
        }
        public static FolderDTO ToDTO(this FolderModel emp)
        {
            if (emp == null)
                return null;
            return new FolderDTO
            {
                Id = emp.Id,
                PathFolder = emp.PathFolder,
                CountFiles = emp.CountFiles,
                CountObject = emp.CountObject,
                CountXmlFiles = emp.CountXmlFiles,
            };
        }
    }
}
