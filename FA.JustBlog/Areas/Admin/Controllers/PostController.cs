using AutoMapper;
using FA.JustBlog.Areas.Admin.Models;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Post")]
public class PostController : BaseController
{
	public PostController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(unitOfWork, mapper, userManager)
	{
	}

	// GET: AdminController
	[Route("")]
	[Authorize(Roles = "User, Contributor, Blog_Owner")]
	public ActionResult Index()
	{
		var posts = _unitOfWork.PostRepository.GetAllPosts();
		return View(posts);
	}

	[Route("Delete/{id:int}")]
	[Authorize(Roles = "Blog_Owner")]
	public ActionResult Delete(int id)
	{
		try
		{
			_unitOfWork.PostRepository.DeletePost(id);
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
		var categories = _unitOfWork.CategoryRepository.GetAllCategories();
		ViewBag.Categories = new SelectList(categories, "Id", "Name");

		var tags = _unitOfWork.TagRepository.GetAllTags();
		ViewBag.Tags = new MultiSelectList(tags, "Id", "Name");

		return View();
	}

	[HttpPost]
	[Route("Create")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	[ValidateAntiForgeryToken]
	public ActionResult Create(PostCreateModel postCreateModel)
	{
		if (ModelState.IsValid)
		{
			if (postCreateModel == null) return RedirectToAction("Index");

			var post = _mapper.Map<Post>(postCreateModel);
			post.PostTagMaps = new List<PostTagMap>();
			var tagIds = postCreateModel.TagIds ?? [];
			foreach (var postVmTagId in tagIds)
			{
				post.PostTagMaps.Add(new PostTagMap()
				{
					Post = post,
					PostId = post.Id,
					Tag = _unitOfWork.TagRepository.GetById(postVmTagId),
					TagId = postVmTagId
				});
			}
			post.PostedOn = DateTime.Now;
			post.Modified = false;
		
			_unitOfWork.PostRepository.Create(post);
			var status = _unitOfWork.SaveChanges();
			if (status > 0)
			{
				TempData["Message"] = "Post added successfully!";
				return RedirectToAction("Index");
			}

			TempData["ErrorMessage"] = "Post added failed";
			return RedirectToAction("Index");
		}

		return View();
	}
	
	[HttpGet]
	[Route("Edit/{id:int}")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	public ActionResult Edit(int id)
	{
		var post = _unitOfWork.PostRepository.FindPost(id);
		if (post != null)
		{
			var categories = _unitOfWork.CategoryRepository.GetAllCategories();
			ViewBag.Categories = new SelectList(categories, "Id", "Name", post.CategoryId);

			var tags = _unitOfWork.TagRepository.GetAllTags();
			ViewBag.Tags = new MultiSelectList(tags, "Id", "Name", post.PostTagMaps.Select(p => p.TagId));
			
			var postVm = _mapper.Map<PostCreateModel>(post);
			return View(postVm);
		}

		return NotFound();
	}
	
	[HttpPost]
	[Route("Edit/{id:int}")]
	[Authorize(Roles = "Contributor, Blog_Owner")]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(int id, PostCreateModel postCreateModel)
	{
		if (ModelState.IsValid)
		{
			if (postCreateModel == null) return RedirectToAction("Index");

			var post = _mapper.Map<Post>(postCreateModel);
			post.PostTagMaps = new List<PostTagMap>();
			var tagIds = postCreateModel.TagIds ?? [];
			foreach (var postVmTagId in tagIds)
			{
				post.PostTagMaps.Add(new PostTagMap()
				{
					Post = post,
					PostId = post.Id,
					Tag = _unitOfWork.TagRepository.GetById(postVmTagId),
					TagId = postVmTagId
				});
			}
			post.PostedOn = DateTime.Now;
			post.Modified = true;
		
			_unitOfWork.PostRepository.UpdatePost(post);
			var status = _unitOfWork.SaveChanges();
			if (status > 0)
			{
				TempData["Message"] = "Post modified successfully!";
				return RedirectToAction("Index");
			}

			TempData["ErrorMessage"] = "Post modified failed!";
			return RedirectToAction("Index");
		}

		return View();
	}

	[HttpPost]
	[Route("Publish/{id}")]
	[Authorize(Roles = "Blog_Owner")]
	public ActionResult Publish(int id)
	{
		var post = _unitOfWork.PostRepository.FindPost(id);
		if (post != null)
		{
			post.Published = !post.Published;
			_unitOfWork.PostRepository.UpdatePost(post);
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