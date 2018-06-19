using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using compare.Models;
using System.Linq;
using System;

namespace compare.Controllers
{
  public class SeedController : Controller
  {
    private DataContext context;

    public SeedController(DataContext ctx) => context = ctx;

    public IActionResult Index()
    {
      ViewBag.Count = context.Products.Count();
      return View(context.Products.Include(p => p.Category).Include(m => m.Manufacture).OrderBy(p => p.Id).Take(20));
    }
    [HttpPost]
    public IActionResult ClearData()
    {
      context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
      context.Database.BeginTransaction();
      context.Database.ExecuteSqlCommand("DELETE FROM Manufactures");
      context.Database.ExecuteSqlCommand("DELETE FROM Categories");
      context.Database.CommitTransaction();
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult CreateProductionData()
    {
      Manufacture bergara = new Manufacture { name = "Bergara" };
      Manufacture mossberg = new Manufacture { name = "Mossberg" };
      Manufacture remington = new Manufacture { name = "Reminton" };
      Manufacture win = new Manufacture { name = "Winchester" };
      Category guns = new Category { name = "guns" };
      Spec weight = new Spec { name = "weight" };
      Spec barrelLength = new Spec { name = "barrel length" };
      Spec capacity = new Spec { name = "magazine capacity" };
      Spec caliber = new Spec { name = "caliber" };
      Spec rifling = new Spec { name = "rifling" };
      Spec lop = new Spec { name = "length of pull" };
      Spec contour = new Spec { name = "barrel contour" };
      Tag accurate = new Tag { name = "accurate" };
      Tag heavy = new Tag { name = "heavy" };
      Tag threaded = new Tag { name = "threaded" };
      Tag aics = new Tag { name = "aics" };
      Tag cerakote = new Tag { name = "cerakote" };
      Tag one = new Tag { name = "one-piece-bolt" };
      Criteria value = new Criteria { name = "value" };
      Criteria performance = new Criteria { name = "value" };
      Criteria construction = new Criteria { name = "construction" };
      Criteria features = new Criteria { name = "feautures" };
      User issac = new User { name = "issac" };
      Product b14 = new Product { Category = guns, Manufacture = bergara, name = "B14 Ridge", price = 850.00, upc = 232131 };
      Product m70 = new Product { Category = guns, Manufacture = win, name = "Model 70 Featherweight", price = 999.00, upc = 048702002151 };
      Product pat = new Product { Category = guns, Manufacture = mossberg, name = "MVP Patrol", price = 733.00, upc = 015813277389 };
      Product remmy = new Product { Category = guns, Manufacture = win, name = "Model 700 CDL", price = 1099, upc = 27007 };
      ProductSpec remweight = new ProductSpec { Product = remmy, Spec = weight, value = 7.4, units = "lbs" };
      ProductSpec remblen = new ProductSpec { Product = remmy, Spec = barrelLength, value = 24, units = "in" };
      ProductSpec remcap = new ProductSpec { Product = remmy, Spec = capacity, value = 4, units = "hinged floorplate" };
      ProductSpec remcal = new ProductSpec { Product = remmy, Spec = caliber, value = 243, units = "rem" };
      ProductSpec remwtwist = new ProductSpec { Product = remmy, Spec = rifling, value = .1111, units = "cm" };
      ProductSpec remlop = new ProductSpec { Product = remmy, Spec = lop, value = 13.5, units = "in" };
     // Review remv = new Review { User = issac, Product = remmy, Criteria = value, score = 3, reviewText = "not a great value too much for what you get", target = "remmy fanboys", date = DateTime.Now };
      //Review remp = new Review { User = issac, Product = remmy, Criteria = performance, score = 4, reviewText = "shot very good", target = "remmy fanboys", date = DateTime.Now };
      context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
  }
}
