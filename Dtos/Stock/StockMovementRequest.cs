using System.ComponentModel.DataAnnotations;
using api_dotnet.Models;

namespace api_dotnet.Dtos;

public record StockMovementRequestDto(
    [Required] int ProductId,
    [Required][Range(1, int.MaxValue)] int Quantity,
    [Required] MovementType Type,
    [Required][MaxLength(200)] string Reason
);