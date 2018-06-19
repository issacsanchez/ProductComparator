using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using compare.Models;
using Microsoft.AspNetCore.Mvc;

namespace compare.Controllers
{
  public class ProductSpecController : Controller
  {
    private IProductSpecRepository productSpecRepo;
    private IProductRepository productRepo;
    private ISpecRepository specRepo;

    public ProductSpecController(IProductSpecRepository ps, IProductRepository p, ISpecRepository s)
    {
      productSpecRepo = ps;
      productRepo = p;
      specRepo = s;

    }
    public IActionResult Index() => View(productSpecRepo.ProductSpecs);

    public IActionResult UpdateProductSpec(long key, bool add)
    {
      ViewBag.Products = productRepo.Products;
      ViewBag.Specs = specRepo.Specs;
      ViewBag.add = add;
      return View(key == 0 ? new ProductSpec() : productSpecRepo.GetProductSpec(key));
    }
    [HttpPost]
    public IActionResult UpdateProductSpec(ProductSpec psP)
    {
      if (psP.Id == 0)
      {
        productSpecRepo.AddProductSpec(psP);
      }
      else
      {
        productSpecRepo.UpdateProductSpec(psP);
      }
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteProductSpec(ProductSpec psP)
    {
      productSpecRepo.DeleteProductSpec(psP);
      return RedirectToAction(nameof(Index));
    }
  }
}
