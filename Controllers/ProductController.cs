using Microsoft.AspNetCore.Mvc;
using MyBackend.DTOs;
using MyBackend.Interfaces;

namespace MyBackend.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _service.GetAllProducts();

            return Ok(products);
        }

        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int id)
        {
            var product = await _service.GetOneProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
