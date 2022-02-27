namespace XmlReader.WEB.Models
{
    public class EmployeeModel: IEntityModel
    {
        /// <summary>
        /// Id работника
        /// </summary>
        public int Id { get; set; } // id
        /// <summary>
        /// роль: рабочий = 0, админ = 1
        /// </summary>
        public bool IsAdmin { get; set; } = false;
        /// <summary>
        /// Имя работника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? NumberPhone { get; set; } // номер телефона
        /// <summary>
        /// Мейл
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Вк
        /// </summary>
        public string? Vk { get; set; }
        /// <summary>
        /// Работы
        /// </summary>
        public ICollection<WorkEmployeeModel>? Works { get; set; }
    }
}
