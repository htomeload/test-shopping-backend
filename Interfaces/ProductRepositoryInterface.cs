using MyBackend.Entities;

namespace MyBackend.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> QueryAllProducts();

        public Task<Product?> QueryOneProduct(int id);
    }
}