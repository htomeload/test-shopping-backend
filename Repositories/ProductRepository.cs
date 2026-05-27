using Microsoft.EntityFrameworkCore;
using MyBackend.DTOs;
using MyBackend.Entities;
using MyBackend.Extensions;
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

        public async Task<IEnumerable<ProductDto>> QueryAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Inventory)
                .ToListAsync();

            var productsDto = new List<ProductDto>();

            foreach (var product in products)
            {
                productsDto.Add(product.ToDto());
            }

            return productsDto;
        }

        public async Task<ProductDto?> QueryOneProduct(int id)
        {
            var product = _context.Products
                .Include(p => p.Inventory)
                .FirstOrDefault(p => p.Id == id);

            return product?.ToDto();
        }
    }
}