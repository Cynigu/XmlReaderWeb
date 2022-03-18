using Models.auth;
using System;

namespace Models
{
    public class UserProfileEntity
    {
        public int Id { get; set; } // id
        public string Name { get; set; } // Имя работника
        public string? NumberPhone { get; set; } // номер телефона
        public string? Email { get; set; }
        public string? Vk { get; set; }
        public int AuthUserId { get; set; }
        public AuthUserEntity AuthUser { get; set; }
        public ICollection<WorkspaceEntity>? Workspaces { get; set; }
        public ICollection<FolderEntity>? Folders { get; set; }
    }
}
