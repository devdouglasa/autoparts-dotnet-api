using System.ComponentModel.DataAnnotations;

namespace api_dotnet.Dtos.Product;

public record ProductCreateDto(
    [Required][MaxLength(100)] string Name,
    string Description,
    [Required] string ManufacturerCode,
    [Required] string Sku,
    [Range(0.01, double.MaxValue)] decimal Price
);
