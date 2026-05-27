using MyBackend.DTOs;
using MyBackend.Interfaces;

namespace MyBackend.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateBatchProductsStock(List<StockUpdateDto> updateList)
        {
            await _repository.UpdateBatchProductsStocks(updateList);
        }

        public async Task<bool> UpdateProductStock(int id, int newQuantity)
        {
            var result = await _repository.UpdateProductStock(id, newQuantity);

            return result;
        }
    }
}