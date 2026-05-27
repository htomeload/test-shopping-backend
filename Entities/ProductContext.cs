using Microsoft.EntityFrameworkCore;

namespace MyBackend.Entities;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
    
    public DbSet<Product> Products => Set<Product>();
    
}