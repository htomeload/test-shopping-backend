using MyBackend.DTOs;

namespace MyBackend.Interfaces
{
    public interface IStockService
    {
        public Task<Boolean> UpdateProductStock(int id, int newQuantity);

        public Task UpdateBatchProductsStock(List<StockUpdateDto> updateList);
    }
}