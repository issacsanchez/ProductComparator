using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class Review
  {
    public long Id { get; set; }
    public decimal score { get; set; }
    public string reviewText { get; set; }
    public string target { get; set; }

    public DateTime date { get; set; }
    public long UserId { get; set; }
    public User User{ get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }

  }
}
