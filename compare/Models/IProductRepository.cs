using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using compare.Models.Pages;

namespace compare.Models
{
  public interface IProductRepository
  {
    IEnumerable<Product> Products { get; }
    Product GetProduct(long key);
    PagedList<Product> GetProducts(QueryOptions options);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void UpdateAll(Product[] products);
    void DeleteProduct(Product product);
  }
}
