using System.ComponentModel.DataAnnotations;

namespace api_dotnet.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Phone { get; set; }
        [Required]
        public int ProfileId { get; set; }
        [Required]
        public UserProfile Profile { get; set; }

        public ICollection<StockMovement> StockMovements { get; set; } = [];

    }
}