using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace compare.Models
{
  public class ProductTagRepository : IProductTagRepository
  {
    private DataContext context;

    public ProductTagRepository(DataContext ctx) => context = ctx;

    public IEnumerable<ProductTag> ProductTags => context.ProductTags.Include(p => p.Product).Include(t => t.Tag).Include(u => u.User);

    public ProductTag GetProductTag(long key) => context.ProductTags.First(p => p.Id == key);
    public void AddProductTag(ProductTag pt)
    {
      context.ProductTags.Add(pt);
      context.SaveChanges();
    }
    public void UpdateProductTag(ProductTag pt)
    {
      ProductTag p = context.ProductTags.Find(pt.Id);
      p.ProductId = pt.ProductId;
      p.TagId = pt.TagId;
      p.UserId = pt.UserId;
      p.opinion = pt.opinion;
      context.SaveChanges();
    }
    public void DeleteProductTag(ProductTag pt)
    {
      context.ProductTags.Remove(pt);
      context.SaveChanges();
    }
  }
}
