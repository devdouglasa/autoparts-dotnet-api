
namespace api_dotnet.Dtos.Stock;

public record StockMovementResponseDto(
    int Id,
    int ProductId,
    int Quantity,
    string Type, 
    string Reason,
    DateTime CreatedAt
);
