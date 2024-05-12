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
[Route("Admin/Tag")]
public class TagController : BaseController
{
	public TagController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(unitOfWork, mapper, userManager)
	{
	}

	// GET: AdminController
	[Route("")]
	[Authorize(Roles = "User, Contributor, Blog_Owner")]
	public ActionResult Index()
	{
		var tags = _unitOfWork.TagRepository.GetAllTags();
		return View(tags);
	}

	[Route("Delete/{id:int}")]
	[Authorize(Roles = "Blog_Owner")]
	public ActionResult Delete(int id)
	{
		try
		{
			_unitOfWork.TagRepository.DeleteTag(id);
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
	public ActionResult Create(Tag tag)
	{
		if (ModelState.IsValid)
		{
			if (tag == null) return RedirectToAction("Index");
		
			_unitOfWork.TagRepository.Create(tag);
			var status = _unitOfWork.SaveChanges();
			if (status > 0)
			{
				TempData["Message"] = "Tag added successfully!";
				return RedirectToAction("Index");
			}

			TempData["ErrorMessage"] = "Tag added failed";
			return RedirectToAction("Index");
		}

		return View();
	}
	
	[HttpGet]
	[Route("Edit/{id:int}")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	public ActionResult Edit(int id)
	{
		var tag = _unitOfWork.TagRepository.GetById(id);
		if (tag != null)
		{
			return View(tag);
		}

		return NotFound();
	}
	
	[HttpPost]
	[Route("Edit/{id:int}")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(int id, Tag tag)
	{
		if (ModelState.IsValid)
		{
			if (tag == null) return RedirectToAction("Index");
		
			_unitOfWork.TagRepository.UpdateTag(tag);
			var status = _unitOfWork.SaveChanges();
			if (status > 0)
			{
				TempData["Message"] = "Tag modified successfully!";
				return RedirectToAction("Index");
			}

			TempData["ErrorMessage"] = "Tag modified failed!";
			return RedirectToAction("Index");
		}

		return View();
	}

	[HttpPost]
	[Route("Publish/{id}")]
	[Authorize(Roles = "Blog_Owner")]
	public ActionResult Publish(int id)
	{
		var tag = _unitOfWork.TagRepository.GetById(id);
		if (tag != null)
		{
			_unitOfWork.TagRepository.UpdateTag(tag);
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