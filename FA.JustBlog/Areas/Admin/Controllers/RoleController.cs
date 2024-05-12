using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers;

[Area("Admin")]
public class RoleController : BaseController
{
	public RoleController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(unitOfWork, mapper, userManager)
	{
	}
	// GET: AdminController
	[Route("Admin/Role")]
	public ActionResult Index()
	{
		return View();
	}
}