namespace XmlReader.BLL.DTO
{
    public enum UserRole
    {
        Admin,
        User
    }
    public class AuthUserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public UserProfileDTO UserProfileDto { get; set; }
    }
}
