

namespace Models
{
    public enum StatusProject
    {
        Process,
        End
    }
    /// <summary>
    /// Рабочая среда - у одного сотрудника может быть несколько работ
    /// </summary>
    public class ProjectEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public ushort CountFactObject
        {
            get
            {
                ushort count = 0;
                if (Folders != null && Folders.Any())
                {
                    var enumerable = Folders.Select(x => x.CountFactObject);
                    foreach (var countObjectInFolder in enumerable)
                    {
                        count += countObjectInFolder;
                    }
                }
                return count;
            }
        }
        public ushort CountFactFiles
        {
            get
            {
                ushort count = 0;
                if (Folders != null && Folders.Any())
                {
                    var enumerable = Folders.Select(x => x.CountFactFiles);
                    foreach (var countInFolder in enumerable)
                    {
                        count += countInFolder;
                    }
                }

                return count;
            }
        }
        public ushort CountPlanFiles
        {
            get
            {
                ushort count = 0;
                if (Folders != null && Folders.Any())
                {
                    var enumerable = Folders.Select(x => x.CountPlanFiles);
                    foreach (var countInFolder in enumerable)
                    {
                        count += countInFolder;
                    }
                }

                return count;
            }
        }
        public DateTime DateStart { get; set; } // Дата начала 
        public DateTime DateEnd { get; set; } // Дата окончания
        public StatusProject Status { get; set; } = StatusProject.Process;
        public ICollection<FolderEntity>? Folders { get; set; }
        public int WorkspaceId { get; set; }
        public WorkspaceEntity WorkspaceEntity { get; set; } = null!;
    }
}
