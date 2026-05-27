using Microsoft.EntityFrameworkCore;

namespace MyBackend.Entities;

public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> options) : base(options) { }
    public DbSet<Stock> Stocks => Set<Stock>();
    
}