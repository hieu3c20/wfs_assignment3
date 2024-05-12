using FA.JustBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Authorization;

namespace FA.JustBlog.Controllers;

[Authorize]
public class HomeController : BaseController
{
    public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public IActionResult Index()
    {
        return RedirectToAction("Index", "Post");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}