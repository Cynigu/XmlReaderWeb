namespace XmlReader.BLL.DTO
{
    public class FolderDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string PathFolder { get; set; }
        public ushort CountObject { get; set; } = 0;
        public ushort CountXmlFiles { get; set; } = 0;
        public ushort CountFiles { get; set; }
        public WorkEmployeeDTO WorkEmployee { get; set; }
    }
}
