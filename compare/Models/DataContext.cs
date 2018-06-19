using Microsoft.EntityFrameworkCore;

namespace compare.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Criteria> Criterias { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Spec> Specs { get; set; }
    public DbSet<ProductSpec> ProductSpecs { get; set; }
    public DbSet<Tag> Tags { get; set; }

  }
}
