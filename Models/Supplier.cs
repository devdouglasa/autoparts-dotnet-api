using System.ComponentModel.DataAnnotations;


namespace api_dotnet.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LegalName { get; set; }
        public string? TradeName { get; set; }
        [Required]
        public string NationalTaxId { get; set; } // CNPJ
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; } = [];
        public ICollection<StockMovement> StockMovements { get; set; } = [];
    }
}