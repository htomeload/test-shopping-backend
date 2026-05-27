using MyBackend.DTOs;
using MyBackend.Interfaces;
using MyBackend.Repositories;

namespace MyBackend.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return await _repository.QueryAllProducts();
        }

        public async Task<ProductDto?> GetOneProduct(int id)
        {
            return await _repository.QueryOneProduct(id);
        }
    }
}