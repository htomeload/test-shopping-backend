using MyBackend.DTOs;

namespace MyBackend.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDto>> QueryAllProducts();

        public Task<ProductDto?> QueryOneProduct(int id);
    }
}