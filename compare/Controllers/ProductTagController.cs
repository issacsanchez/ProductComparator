using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using compare.Models;

namespace compare.Controllers
{
  public class ProductTagController : Controller
  {
    private IProductTagRepository productTagRepo;
    private IProductRepository productRepo;
    private ITagRepository tagRepo;
    private IUserRepository userRepo;

    public ProductTagController(IProductTagRepository pt, IProductRepository p, ITagRepository t, IUserRepository u)
    {
      productTagRepo = pt;
      productRepo = p;
      tagRepo = t;
      userRepo = u;
    }
    public IActionResult Index() => View(productTagRepo.ProductTags);
    public IActionResult UpdateProductTag(long key, bool add)
    {
      ViewBag.Products = productRepo.Products;
      ViewBag.Tags = tagRepo.Tags;
      ViewBag.Users = userRepo.Users;
      ViewBag.add = add;
      return View(key == 0 ? new ProductTag() : productTagRepo.GetProductTag(key));
    }
    [HttpPost]
    public IActionResult UpdateProductTag(ProductTag pt)
    {
      if (pt.Id == 0)
      {
        productTagRepo.AddProductTag(pt);
      }
      else
      {
        productTagRepo.UpdateProductTag(pt);
      }
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteProductTag(ProductTag pt)
    {
      productTagRepo.DeleteProductTag(pt);
      return RedirectToAction(nameof(Index));
    }
  }
}
