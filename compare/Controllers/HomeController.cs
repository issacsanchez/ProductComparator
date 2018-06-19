using Microsoft.AspNetCore.Mvc;
using compare.Models;
using System.Linq;
using System;
using compare.Models.Pages;

namespace compare.Controllers
{
  public class HomeController : Controller
  {
    private IProductRepository productRepository;
    private IManufactureRepository manufactureRepository;
    private ICategoryRepository categoryRepository;

    public HomeController(IProductRepository prodRepo, IManufactureRepository manuRepo, ICategoryRepository catRepo)
    {
      productRepository = prodRepo;
      manufactureRepository = manuRepo;
      categoryRepository = catRepo;
    }
    public IActionResult Index(QueryOptions options)
    {
      var view_data = productRepository.GetProducts(options);
      return View(view_data);
    }
    public IActionResult UpdateProduct(long key, bool add)
    {
      ViewBag.Manufactures = manufactureRepository.Manufactures;
      ViewBag.Categories = categoryRepository.Categories;
      ViewBag.add = add;
      return View(key == 0 ? new Product() : productRepository.GetProduct(key));
    }
    [HttpPost]
    public IActionResult UpdateProduct(Product product)
    {
      if (product.Id == 0)
      {
        //add maufacture to manufactures, get manufacture id and insert intp product, then add
        productRepository.AddProduct(product);
      }
      else
      {
        productRepository.UpdateProduct(product);
      }
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteProduct(Product product)
    {
      productRepository.DeleteProduct(product);
      return RedirectToAction(nameof(Index));
    }
  }
}
