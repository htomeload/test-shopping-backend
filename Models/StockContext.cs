using Microsoft.EntityFrameworkCore;

namespace MyBackend.Models;

public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> options) : base(options) { }
    public DbSet<Stock> Stocks => Set<Stock>();
    
}