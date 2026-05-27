using MyBackend.DTOs;

namespace MyBackend.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAllProducts();

        public Task<ProductDto?> GetOneProduct(int id);
    }
}