using api_dotnet.Models;
using api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers
{
    [Route("[controller]")]
    public class ProductController(ProductService productService) : Controller
    {
        private readonly ProductService _productService = productService;

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {   
            var products = await _productService.GetAll();

            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if(product is null)
            {
                return NotFound(new { message = "Produto não encontrado!" });
            }

            return Ok(product);
        }
    }
}