using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using compare.Models;

namespace compare.Controllers
{
  public class CriteriaController : Controller
  {
    private ICriteriaRepository repository;

    public CriteriaController(ICriteriaRepository repo) => repository = repo;

    public IActionResult Index() => View(repository.Criterias);
    [HttpPost]
    public IActionResult AddCriteria(Criteria criteria)
    {
      repository.AddCriteria(criteria);
      return RedirectToAction(nameof(Index));
    }
    public IActionResult EditCriteria(long id)
    {
      ViewBag.EditId = id;
      return View("Index", repository.Criterias);
    }
    [HttpPost]
    public IActionResult UpdateCriteria(Criteria criteria)
    {
      repository.UpdateCriteria(criteria);
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteCriteria(Criteria criteria)
    {
      repository.DeleteCriteria(criteria);
      return RedirectToAction(nameof(Index));
    }
  }
}
