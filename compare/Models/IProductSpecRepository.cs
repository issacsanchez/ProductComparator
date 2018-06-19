using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface IProductSpecRepository
  {
    IEnumerable<ProductSpec> ProductSpecs { get; }

    ProductSpec GetProductSpec(long key);
    void AddProductSpec(ProductSpec ps);
    void UpdateProductSpec(ProductSpec ps);
    void DeleteProductSpec(ProductSpec ps);

  }
}
