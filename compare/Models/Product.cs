using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class Product
  {
    public long Id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public long upc { get; set; }
    public long ManufactureId { get; set; }
    public Manufacture Manufacture { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
  }
}
