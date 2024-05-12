using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers;

[Authorize]
public class TagController : BaseController
{
    public TagController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // GET: TagController
    public ActionResult Index()
    {
        return View();
    }
}