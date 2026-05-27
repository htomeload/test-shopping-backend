using MyBackend.DTOs;

namespace MyBackend.Interfaces
{
    public interface IStockRepository
    {
        public Task<Boolean> UpdateProductStock(int id, int newQuantity);

        public Task UpdateBatchProductsStocks(List<StockUpdateDto> updates);
    }
}