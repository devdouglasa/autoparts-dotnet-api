
namespace api_dotnet.Dtos.Product;

public record ProductResponseDto(
    int Id,
    string Name,
    string Description,
    string ManufacturerCode,
    string Sku,
    int Quantity,
    decimal Price,
    DateTime CreatedAt
);
