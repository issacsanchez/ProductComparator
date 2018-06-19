using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using compare.Models;

namespace compare.Controllers
{
  public class ReviewController : Controller
  {
    private IReviewRepository repo;
    private IUserRepository userRepo;
    private IProductRepository productRepo;
    private ICriteriaRepository criteriaRepo;

    public ReviewController(IReviewRepository repoR, IUserRepository uRepo, IProductRepository pRepo,ICriteriaRepository cRepo)
    {
      repo = repoR;
      userRepo = uRepo;
      productRepo = pRepo;
      criteriaRepo = cRepo;
    }
    public IActionResult Index() => View(repo.Reviews);
    public IActionResult UpdateReview(long key)
    {
      ViewBag.Users = userRepo.Users;
      ViewBag.Products = productRepo.Products;
      ViewBag.Criterias = criteriaRepo.Criterias;
      return View(key == 0 ? new Review() : repo.GetReview(key));
    }
    [HttpPost]
    public IActionResult UpdateReview(Review reviewP)
    {
      reviewP.date = DateTime.Now;
      if (reviewP.Id == 0)
      {
        //add maufacture to manufactures, get manufacture id and insert intp product, then add
        repo.AddReview(reviewP);
      }
      else
      {
        repo.UpdateReview(reviewP);
      }
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteReview(Review reviewP)
    {
      repo.DeleteReview(reviewP);
      return RedirectToAction(nameof(Index));
    }

  }
}
