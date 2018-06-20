using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace compare.Models
{
  public class ReviewRepository : IReviewRepository
  {
    private DataContext context;
    public ReviewRepository(DataContext ctx) => context = ctx;

    public IEnumerable<Review> Reviews => context.Reviews.Include(l => l.User).Include( c => c.Product).ToArray();
    public Review GetReview(long key) => context.Reviews.Include(u => u.User).Include(c => c.Product).First(y => y.Id == key);

    public void AddReview(Review reviewP)
    {
      context.Reviews.Add(reviewP);
      context.SaveChanges();
    }
    public void UpdateReview(Review reviewP)
    {
      Review p = context.Reviews.Find(reviewP.Id);
      p.UserId = reviewP.UserId;
      p.ProductId = reviewP.ProductId;
      p.value = reviewP.value;
      p.performance = reviewP.performance;
      p.construction = reviewP.construction;
      p.features = reviewP.features;
      p.reviewText = reviewP.reviewText;
      p.bestFor = reviewP.bestFor;
      context.SaveChanges();
    }
    public void DeleteReview(Review review)
    {
      context.Reviews.Remove(review);
      context.SaveChanges();
    }
  }
}