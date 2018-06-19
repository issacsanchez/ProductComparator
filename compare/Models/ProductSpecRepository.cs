using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace compare.Models
{
  public class ProductSpecRepository : IProductSpecRepository
  {
    private DataContext context;

    public ProductSpecRepository(DataContext ctx) => context = ctx;

    public IEnumerable<ProductSpec> ProductSpecs => context.ProductSpecs.Include(p => p.Product).Include(s => s.Spec);

    public ProductSpec GetProductSpec(long key) => context.ProductSpecs.First(p => p.Id == key);
    public void AddProductSpec(ProductSpec psP)
    {
      context.ProductSpecs.Add(psP);
      context.SaveChanges();
    }
    public void UpdateProductSpec(ProductSpec psP)
    {
      ProductSpec p = context.ProductSpecs.Find(psP.Id);
      p.ProductId = psP.ProductId;
      p.SpecId = psP.SpecId;
      p.value = psP.value;
      p.units = psP.units;
      context.SaveChanges();
    }
    public void DeleteProductSpec(ProductSpec psP)
    {
      context.ProductSpecs.Remove(psP);
      context.SaveChanges();
    }

  }
}
