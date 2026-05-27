using MyBackend.DTOs;
using MyBackend.Extensions;
using MyBackend.Interfaces;

namespace MyBackend.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _repository.QueryAllProducts();

            var productsDto = new List<ProductDto>();

            foreach (var product in products)
            {
                productsDto.Add(product.ToDto());
            }

            return productsDto;
        }

        public async Task<ProductDto?> GetOneProduct(int id)
        {
            var product = await _repository.QueryOneProduct(id);

            return product?.ToDto();
        }
    }
}