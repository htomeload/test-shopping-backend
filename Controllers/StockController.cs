using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackend.Models;

namespace MyBackend.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockContext _context;

        public StockController(StockContext context)
        {
            _context = context;
        }

        [HttpPatch]
        [Route("UpdateProductStock/{id}")]
        public async Task<IActionResult> PatchProductStockAsync(int id, int newQuantity)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.ProductId == id);
    
            if (stock == null) return NotFound();

            stock.Quantity = newQuantity;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpPost]
        [Route("UpdateBatchStock")]
        public async Task<ActionResult> PostUpdateProductsStockAsync(List<StockUpdateDto> updates)
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
                if (stock != null)
                {
                    stock.Quantity = update.NewQuantity;
                }
            }

            // Save all changes in a single database transaction
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Successfully updated {stocksToUpdate.Count} items." });
        }
    }
}