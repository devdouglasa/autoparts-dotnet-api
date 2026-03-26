using api_dotnet.Data;
using api_dotnet.Models;

namespace api_dotnet.Services
{
    public interface IStockService
    {
        Task<bool> UpdateStockAsync(int productId, int quantity, MovementType type, string reason);
    }

    public class StockService(AppDbContext context) : IStockService
    {
        private readonly AppDbContext _context = context;


        public async Task<bool> UpdateStockAsync(int productId, int quantity, MovementType type, string reason)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return false;

            // Lógica de negócio
            if (type == MovementType.Outbound)
            {
                if (product.Quantity < quantity) return false; // Estoque insuficiente
                product.Quantity -= quantity;
            }
            else
            {
                product.Quantity += quantity;
            }

            // Registra a movimentação
            var movement = new StockMovement
            {
                ProductId = productId,
                Quantity = quantity,
                Type = type,
                Reason = reason
            };

            _context.StockMovements.Add(movement);
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}