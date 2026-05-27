using Microsoft.AspNetCore.Mvc;
using MyBackend.DTOs;
using MyBackend.Interfaces;

namespace MyBackend.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;

        public StockController(IStockService service)
        {
            _service = service;
        }

        [HttpPatch]
        [Route("UpdateProductStock/{id}")]
        public async Task<IActionResult> PatchProductStockAsync(int id, int newQuantity)
        {
            var result = await _service.UpdateProductStock(id, newQuantity);
    
            if (!result) return NotFound();
            
            return NoContent();
        }

        [HttpPost]
        [Route("UpdateBatchStock")]
        public async Task<ActionResult> PostUpdateProductsStockAsync(List<StockUpdateDto> updates)
        {
            await _service.UpdateBatchProductsStock(updates);

            return Ok(new { Message = $"Successfully updated {updates.Count} items." });
        }
    }
}