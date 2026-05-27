using MyBackend.DTOs;
using MyBackend.Entities;

namespace MyBackend.Extensions
{
    public static class ProductExtension
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
              Id = product.Id,
              Name = product.Name,
              Price = product.Price,
              Sku = product.Sku,
              Inventory = product.Inventory?.ToDto(),
            };
        }
    }
}