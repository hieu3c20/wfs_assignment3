using System.Security.Claims;
using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FA.JustBlog.Areas.Admin.Controllers;

public class BaseController : Controller
{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IMapper _mapper;
	private readonly UserManager<AppUser> _userManager;

	public BaseController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_userManager = userManager;
	}

	public override void OnActionExecuting(ActionExecutingContext context)
	{
		ClaimsPrincipal currentUser = this.User;
		var currentUserName = currentUser.FindFirst(ClaimTypes.Email)?.Value;
		if (currentUserName != null)
		{
			var user = _userManager.FindByEmailAsync(currentUserName).Result;
			TempData["User"] = user;
			
			var roles = _userManager.GetRolesAsync(user).Result;
			TempData["Roles"] = roles;
		}
		base.OnActionExecuting(context);
	}
}