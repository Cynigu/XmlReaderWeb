namespace XmlReader.BLL.DTO
{
    public enum FolderStatus
    {
        Process,
        End
    }
    public class FolderDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PathFolder { get; set; }
        public DateTime DateStart { get; set; } // Дата начала 
        public DateTime DateEnd { get; set; } // Дата окончания
        public ushort CountFactObject { get; set; } = 0;
        public ushort CountFactFiles { get; set; } = 0;
        public ushort CountPlanFiles { get; set; }
        public int WorkId { get; set; }
        public ProjectDTO Project { get; set; }
        public FolderStatus Status { get; set; } = FolderStatus.Process;
    }
}