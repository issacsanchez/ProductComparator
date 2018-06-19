using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
    public class ProductTag
    {
    public long Id { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long TagId { get; set; }
    public Tag Tag { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public double value { get; set; }
    public string units { get; set; }
    public int opinion { get; set; }
  }
}
