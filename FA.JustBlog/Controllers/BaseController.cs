using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FA.JustBlog.Controllers;

[Authorize]
public class BaseController : Controller
{
	protected readonly IUnitOfWork _unitOfWork;

	public BaseController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void OnActionExecuting(ActionExecutingContext context)
	{
		var categories = _unitOfWork.CategoryRepository.GetAllCategories();
		ViewData["Categories"] = categories;
		base.OnActionExecuting(context);
	}
}