namespace Models;

public enum PofileInProjectRole
{
    Admin, Manager, Employee
}

public class WorkspaceEntity
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfileEntity UserProfile { get; set; } = null!;
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
    public PofileInProjectRole ProjectRole { get; set; } = PofileInProjectRole.Admin;

}