using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers;

[Authorize]
public class AboutController : BaseController
{
    public AboutController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    // GET: AboutController
    public ActionResult Index()
    {
        return View();
    }
}