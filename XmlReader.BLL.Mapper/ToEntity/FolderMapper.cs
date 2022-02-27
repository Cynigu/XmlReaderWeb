using Models;
using XmlReader.BLL.DTO;

namespace XmlReader.BLL.Mapper.ToEntity
{
    public static class FolderMapper
    {
        public static FolderDTO ToDTO(this Folder emp)
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

        public static Folder ToEntity(this FolderDTO emp)
        {
            if (emp == null)
                return null;
            return new Folder
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
