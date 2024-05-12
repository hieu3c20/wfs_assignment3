using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers;

[Area("Admin")]
public class CommentController : BaseController
{
    // GET: AdminController
    [Route("Admin/Comment")]
    public ActionResult Index()
    {
        return View();
    }

    public CommentController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(unitOfWork, mapper, userManager)
    {
    }
}