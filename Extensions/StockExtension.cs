using MyBackend.DTOs;
using MyBackend.Entities;

namespace MyBackend.Extensions
{
    public static class StockExtension
    {
        public static StockDto ToDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
        }
    }
}