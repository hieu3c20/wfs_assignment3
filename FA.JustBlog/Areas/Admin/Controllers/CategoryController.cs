using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Identities;
using FA.JustBlog.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Category")]
public class CategoryController : BaseController
{
	public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(unitOfWork, mapper, userManager)
	{
	}

	// GET: AdminController
	[Route("")]
	[Authorize(Roles = "User, Contributor, Blog_Owner")]
	public ActionResult Index()
	{
		var posts = _unitOfWork.CategoryRepository.GetAllCategories();
		return View(posts);
	}

	[Route("Delete/{id:int}")]
	[Authorize(Roles = "Blog_Owner")]
	public ActionResult Delete(int id)
	{
		try
		{
			_unitOfWork.CategoryRepository.DeleteCategory(id);
			var response = _unitOfWork.SaveChanges();
			if (response > 0)
			{
				return RedirectToAction("Index");
			}

			return NotFound();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			return NotFound();
		}
	}
	
	[HttpGet]
	[Route("Create")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[Route("Create")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	[ValidateAntiForgeryToken]
	public ActionResult Create(Category category)
	{
		if (ModelState.IsValid)
		{
			if (category == null) return RedirectToAction("Index");
		
			_unitOfWork.CategoryRepository.Create(category);
			var status = _unitOfWork.SaveChanges();
			if (status > 0)
			{
				TempData["Message"] = "Category added successfully!";
				return RedirectToAction("Index");
			}

			TempData["ErrorMessage"] = "Category added failed";
			return RedirectToAction("Index");
		}

		return View();
	}
	
	[HttpGet]
	[Route("Edit/{id:int}")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	public ActionResult Edit(int id)
	{
		var category = _unitOfWork.CategoryRepository.GetById(id);
		if (category != null)
		{
			return View(category);
		}

		return NotFound();
	}
	
	[HttpPost]
	[Route("Edit/{id:int}")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(int id, Category category)
	{
		if (ModelState.IsValid)
		{
			if (category == null) return RedirectToAction("Index");
		
			_unitOfWork.CategoryRepository.UpdateCategory(category);
			var status = _unitOfWork.SaveChanges();
			if (status > 0)
			{
				TempData["Message"] = "Category modified successfully!";
				return RedirectToAction("Index");
			}

			TempData["ErrorMessage"] = "Category modified failed!";
			return RedirectToAction("Index");
		}

		return View();
	}

	[HttpPost]
	[Route("Publish/{id}")]
	[Authorize(Roles = "Blog_Owner")]
	public ActionResult Publish(int id)
	{
		var category = _unitOfWork.CategoryRepository.GetById(id);
		if (category != null)
		{
			_unitOfWork.CategoryRepository.UpdateCategory(category);
			var result = _unitOfWork.SaveChanges();
			if (result > 0)
			{
				return RedirectToAction("Index");
			}

			return NotFound();
		}

		return NotFound();
	}
}