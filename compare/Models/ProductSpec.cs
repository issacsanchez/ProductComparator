using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class ProductSpec
  {
    public long Id { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long SpecId { get; set; }
    public Spec Spec { get; set; }
    public double value { get; set; }
    public string units { get; set; }
  }
}
