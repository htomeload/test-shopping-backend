using Microsoft.AspNetCore.Mvc;
using MyBackend.Entities;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var product = await _service.GetAllProducts();

            return Ok(product);
        }

        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
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
