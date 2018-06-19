using Microsoft.AspNetCore.Mvc;
using compare.Models;


namespace compare.Controllers
{
  public class ManufactureController : Controller
  {
    private IManufactureRepository repository;

    public ManufactureController(IManufactureRepository repo) => repository = repo;

    public IActionResult Index() => View(repository.Manufactures);
    [HttpPost]
    public IActionResult AddManufacture(Manufacture manufacture)
    {
      repository.AddManufacture(manufacture);
      return RedirectToAction(nameof(Index));
    }
    public IActionResult EditManufacture(long id)
    {
      ViewBag.EditId = id;
      return View("Index", repository.Manufactures);
    }
    [HttpPost]
    public IActionResult UpdateManufacture(Manufacture manufacture)
    {
      repository.UpdateManufacture(manufacture);
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteManufacture(Manufacture manufacture)
    {
      repository.DeleteManufacture(manufacture);
      return RedirectToAction(nameof(Index));
    }
  }
}
