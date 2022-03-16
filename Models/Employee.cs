using Models.auth;
using System;

namespace Models
{
    public class Employee: IEntity
    {
        public int Id { get; set; } // id
        public bool IsAdmin { get; set; } = false;// роль: рабочий = 0, админ = 1
        public string Name { get; set; } // Имя работника
        public string? NumberPhone { get; set; } // номер телефона
        public string? Email { get; set; }
        public string? Vk { get; set; }
        public ICollection<WorkEmployee>? Works { get; set; }
        public int AuthUserId { get; set; }
        public AuthUser AuthUser { get; set; }
    }
}
