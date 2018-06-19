using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using compare.Models;

namespace compare.Controllers
{
    public class TagController : Controller
    {
    private ITagRepository repository;

    public TagController(ITagRepository tagRepo)
    {
      repository = tagRepo;
    }
    public IActionResult Index() => View(repository.Tags);
    [HttpPost]
    public IActionResult AddTag(Tag tagP)
    {
      repository.AddTag(tagP);
      return RedirectToAction(nameof(Index));
    }
    public IActionResult EditTag(long id)
    {
      ViewBag.EditId = id;
      return View("Index", repository.Tags);

    }
    [HttpPost]
    public IActionResult UpdateTag(Tag tagP)
    {
      repository.UpdateTag(tagP);
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteTag(Tag tagP)
    {
      repository.DeleteTag(tagP);
      return RedirectToAction(nameof(Index));
    }
  }
}
