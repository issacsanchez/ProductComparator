using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface IProductTagRepository
  {
    IEnumerable<ProductTag> ProductTags { get; }

    ProductTag GetProductTag(long key);
    void AddProductTag(ProductTag pt);
    void UpdateProductTag(ProductTag pt);
    void DeleteProductTag(ProductTag pt);
  }
}
