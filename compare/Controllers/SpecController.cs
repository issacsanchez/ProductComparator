using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using compare.Models;

namespace compare.Controllers
{
  public class SpecController : Controller
  {
    private ISpecRepository repository;

    public SpecController(ISpecRepository specRepo)
    {
      repository = specRepo;
    }
    public IActionResult Index() => View(repository.Specs);
    [HttpPost]
    public IActionResult AddSpec(Spec specP)
    {
      repository.AddSpec(specP);
      return RedirectToAction(nameof(Index));
    }
    public IActionResult EditSpec(long id)
    {
      ViewBag.EditId = id;
      return View("Index", repository.Specs);

    }
    [HttpPost]
    public IActionResult UpdateSpec(Spec specP)
    {
      repository.UpdateSpec(specP);
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteSpec(Spec specP)
    {
      repository.DeleteSpec(specP);
      return RedirectToAction(nameof(Index));
    }
  }
}
