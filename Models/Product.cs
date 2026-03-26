using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_dotnet.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string ManufacturerCode { get; set; }
        [Required]
        public string Sku { get; set; } // Internal Code
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Table Relationship
        [JsonIgnore]
        public virtual ICollection<StockMovement> StockMovements { get; set; } = [];
    }
}
