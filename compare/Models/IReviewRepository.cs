using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface IReviewRepository
  {
    IEnumerable<Review> Reviews { get;}

    Review GetReview(long key);
    void AddReview(Review reviewP);
    void UpdateReview(Review reviewP);
    void DeleteReview(Review reviewP);

  }
}
