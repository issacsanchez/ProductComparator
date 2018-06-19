using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using compare.Models.Pages;

namespace compare.Models
{
  public class ProductRepository : IProductRepository
  {
    private DataContext context;

    public ProductRepository(DataContext ctx) => context = ctx;

    public IEnumerable<Product> Products => context.Products
      .Include(p => p.Manufacture).Include(l => l.Category).ToArray();

    public Product GetProduct(long key) => context.Products
      .Include(p => p.Manufacture).First(p => p.Id == key);
    public PagedList<Product> GetProducts(QueryOptions options)
    {
      return new PagedList<Product>(context.Products.Include(p => p.Manufacture).Include(l => l.Category), options);
    }

    public void AddProduct(Product product)
    {
      context.Products.Add(product);
      context.SaveChanges();
    }
    public void UpdateProduct(Product product)
    {
      Product p = context.Products.Find(product.Id);
      p.name = product.name;
      p.price = product.price;
      p.upc = product.upc;
      p.ManufactureId = product.ManufactureId;
      p.CategoryId = product.CategoryId;
      context.SaveChanges();
    }
    public void UpdateAll(Product[] products)
    {
      Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
      IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.Id));
      foreach(Product databaseProduct in baseline)
      {
        Product requestProduct = data[databaseProduct.Id];
        databaseProduct.name = requestProduct.name;
        databaseProduct.price = requestProduct.price;
        databaseProduct.upc = requestProduct.upc;
        databaseProduct.Manufacture = requestProduct.Manufacture;
        databaseProduct.Category = requestProduct.Category;
      }
      context.SaveChanges();
    }
    public void DeleteProduct(Product product)
    {
      context.Products.Remove(product);
      context.SaveChanges();
    }
  }
}