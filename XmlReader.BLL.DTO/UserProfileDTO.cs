namespace XmlReader.BLL.DTO
{
    public class UserProfileDTO
    {
        public int Id { get; set; } // id
        public string Name { get; set; } // Имя работника
        public string? NumberPhone { get; set; } // номер телефона
        public string? Email { get; set; }
        public string? Vk { get; set; }
        public int AuthUserId { get; set; }
    }
}
