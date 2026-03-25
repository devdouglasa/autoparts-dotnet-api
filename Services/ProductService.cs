using api_dotnet.Data;
using api_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Services
{
    public class ProductService(AppDbContext appDbContext)
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<List<Product>> GetAll()
        {
            var products = await _appDbContext.Products.ToListAsync();

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id);

            return product;
        }
    }
}