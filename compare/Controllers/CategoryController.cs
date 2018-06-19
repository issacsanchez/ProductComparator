﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using compare.Models;

namespace compare.Controllers
{
  public class CategoryController : Controller
  {
    private ICategoryRepository repository;

    public CategoryController(ICategoryRepository repo) => repository = repo;

    public IActionResult Index() => View(repository.Categories);
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
      repository.AddCategory(category);
      return RedirectToAction(nameof(Index));
    }
    public IActionResult EditCategory(long id)
    {
      ViewBag.EditId = id;
      return View("Index", repository.Categories);
    }
    [HttpPost]
    public IActionResult UpdateCategory(Category category)
    {
      repository.UpdateCategory(category);
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteCategory(Category category)
    {
      repository.DeleteCategory(category);
      return RedirectToAction(nameof(Index));
    }
  }
}
