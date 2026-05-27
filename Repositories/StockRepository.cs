using Microsoft.EntityFrameworkCore;
using MyBackend.DTOs;
using MyBackend.Entities;
using MyBackend.Interfaces;

namespace MyBackend.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly StockContext _context;

        public StockRepository(StockContext context)
        {
            _context = context;
        }

        public async Task UpdateBatchProductsStocks(List<StockUpdateDto> updates)
        {
            // Extract all IDs from the request
            var productIds = updates.Select(u => u.ProductId).ToList();

            // Fetch only the stocks that need updating
            var stocksToUpdate = await _context.Stocks
                .Where(s => productIds.Contains(s.ProductId))
                .ToListAsync();

            // Apply the new quantities
            foreach (var update in updates)
            {
                var stock = stocksToUpdate.FirstOrDefault(s => s.ProductId == update.ProductId);
                stock?.Quantity = update.NewQuantity;
            }

            // Save all changes in a single database transaction
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductStock(int id, int newQuantity)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.ProductId == id);
    
            if (stock != null) {
                stock.Quantity = newQuantity;
                await _context.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }
    }
}