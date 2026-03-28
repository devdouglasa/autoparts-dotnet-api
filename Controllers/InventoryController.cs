using api_dotnet.Dtos;
using api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers
{
    [ApiController]
    [Route("api/iventory")]
    public class InventoryController(IStockService stockService) : ControllerBase
    {
        private readonly IStockService _stockService = stockService;


        [HttpPost("movement")]
        public async Task<IActionResult> PostMovement([FromBody] StockMovementRequestDto request)
        {
            var result = await _stockService.UpdateStockAsync(
                request.ProductId,
                request.Quantity,
                request.Type,
                request.Reason
            );

            if (!result) return BadRequest("Unable to process stock movement. Check product ID or availability.");

            return Ok("Stock updated successfully.");
        }
    }
}