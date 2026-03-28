using api_dotnet.Dtos.Product;
using api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController(ProductService productService) : Controller
    {
        private readonly ProductService _productService = productService;

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> Create(ProductCreateDto dto)
        {
            var product = await _productService.Create(dto);

            var response = new ProductResponseDto(
                product.Id, product.Name, product.Description,
                product.ManufacturerCode, product.Sku, product.Quantity,
                product.Price, product.CreatedAt
            );

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
        {
            var products = await _productService.GetAll();

            return products;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById([FromRoute] int id)
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