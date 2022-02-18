using System;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; } // id
        public bool IsAdmin { get; set; } // роль: рабочий = 0, админ = 1
        public string Name { get; set; } // Имя работника
        public ICollection<WorkEmployee> Works { get; set; }
    }
}
