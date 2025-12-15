namespace TaskManager.API.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
