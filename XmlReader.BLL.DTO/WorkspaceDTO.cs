namespace XmlReader.BLL.DTO;

public enum PofileInProjectRole
{
    Admin, Manager, Employee
}

public class WorkspaceDTO
{
    public int Id { get; set; }
    public ICollection<ProjectDTO> ProjectEntity { get; set; } = null!;
    public int UserProfileEntityId { get; set; }
    public UserProfileDTO UserProfileDto { get; set; } = null!;
    public ICollection<FolderDTO> FolderEntities { get; set; } = null!;
    public PofileInProjectRole ProjectRole { get; set; } = PofileInProjectRole.Admin;

}