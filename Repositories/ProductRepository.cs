using Microsoft.EntityFrameworkCore;
using MyBackend.Entities;
using MyBackend.Interfaces;

namespace MyBackend.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> QueryAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Inventory)
                .ToListAsync();

            return products;
        }

        public async Task<Product?> QueryOneProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }
    }
}