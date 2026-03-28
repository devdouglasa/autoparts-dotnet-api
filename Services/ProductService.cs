using api_dotnet.Data;
using api_dotnet.Models;
using api_dotnet.Dtos.Product;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Services
{
    public class ProductService(AppDbContext appDbContext)
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<List<ProductResponseDto>> GetAll()
        {
            var products = await _appDbContext.Products
                .AsNoTracking()
                .Select(p => new ProductResponseDto(
                    p.Id,
                    p.Name,
                    p.Description,
                    p.ManufacturerCode,
                    p.Sku,
                    p.Quantity,
                    p.Price,
                    p.CreatedAt
                )).ToListAsync();

            return products;
        }

        public async Task<ProductResponseDto> GetProductById(int id)
        {
            var product = await _appDbContext.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductResponseDto(
                    p.Id,
                    p.Name,
                    p.Description,
                    p.ManufacturerCode,
                    p.Sku,
                    p.Quantity,
                    p.Price,
                    p.CreatedAt
                )).FirstOrDefaultAsync();;

            return product;
        }
    }
}