using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using compare.Models;

namespace compare.Controllers
{
  public class UserController : Controller
  {
    private IUserRepository repository;

    public UserController(IUserRepository repo) => repository = repo;

    public IActionResult Index() => View(repository.Users);
    [HttpPost]
    public IActionResult AddUser(User user)
    {
      repository.AddUser(user);
      return RedirectToAction(nameof(Index));
    }
    public IActionResult EditUser(long id)
    {
      ViewBag.EditId = id;
      return View("Index", repository.Users);
    }
    [HttpPost]
    public IActionResult UpdateUser(User user)
    {
      repository.UpdateUser(user);
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult DeleteUser(User user)
    {
      repository.DeleteUser(user);
      return RedirectToAction(nameof(Index));
    }
  }
}
