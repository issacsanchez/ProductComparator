using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using compare.Models;
using System.Linq;


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
      Manufacture Bergara = new Manufacture { name = "Bergara" };
      Category guns = new Category { name = "guns" };
      Category electronics = new Category { name = "electronics" };
      Category clothing = new Category { name = "clothing" };
      context.Products.AddRange(
        new Product
        {
          Category = guns,
          Manufacture = Bergara,
          name = "B14 Ridge",
          price = 850.00,
          upc = 232131
        },
        new Product
        {
          Category = guns,
          Manufacture = Bergara,
          name = "B14 Hunter",
          price = 750.00,
          upc = 756567
        },
        new Product
        {
          Category = guns,
          Manufacture = Bergara,
          name = "B14 Woodsman",
          price = 700.00,
          upc = 75649867
        },
        new Product
        {
          Category = guns,
          Manufacture = new Manufacture { name = "Winchester"},
          name = "Model 70 Sporter",
          price = 1000.00,
          upc = 989012
        },
        new Product
        {
          Category = guns,
          Manufacture = new Manufacture { name = "Remington"},
          name = "870 Waterfowl",
          price = 900.00,
          upc = 12312421
        },
        new Product {
          Category = guns,
          Manufacture = new Manufacture { name = "Springfield"},
          name = "M1A Loaded",
          price = 1800.00,
          upc = 09814234
        },
        new Product {
          Category = guns,
          Manufacture = new Manufacture { name = "Browning"},
          name = "X Bolt Hells Canyon",
          price = 1300,
          upc = 4309123
        },
        new Product
        {
          Category = electronics,
          Manufacture = new Manufacture { name = "Beyerdynamic"},
          name = "DT-900",
          price = 178.00,
          upc = 12934589
        },
        new Product
        {
          Category = electronics,
          Manufacture = new Manufacture { name = "AKG"},
          name = "K 701",
          price = 208.95,
          upc = 3542342389
        },
        new Product
        {
          Category = electronics,
          Manufacture = new Manufacture { name = "Senheiser"},
          name ="HD 600",
          price = 286.00,
          upc = 6456543454
        },
        new Product
        {
          Category = electronics,
          Manufacture = new Manufacture { name = "Audio-Technica"},
          name = "ATH-AD700",
          price = 101.00,
          upc = 89789112
        },
        new Product
        {
          Category = clothing,
          Manufacture = new Manufacture { name = "Arc'teryx"},
          name = "Cerium LT Hoody",
          price = 379.00,
          upc = 9891237890
        },
        new Product
        {
          Category = clothing,
          Manufacture = new Manufacture { name = "Patagonia"},
          name = "Down Sweater",
          price = 229.00,
          upc = 7686123090
        },
        new Product
        {
          Category = clothing,
          Manufacture = new Manufacture { name = "REI"},
          name = "Down Jacket",
          price = 99.50,
          upc = 11229944
        },
        new Product
        {
          Category = clothing,
          Manufacture = new Manufacture { name = "Mountain Equipment"},
          name = "Lightline",
          price = 250.00,
          upc = 996622445
        }
        );
      context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
  }
}
