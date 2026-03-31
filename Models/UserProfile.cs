using System.ComponentModel.DataAnnotations;

namespace api_dotnet.Models
{
    public enum UserRole
    {
        Admin = 1,
        User = 2
    }
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public UserRole Role { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<User> Users { get; set; } = [];
    }
}