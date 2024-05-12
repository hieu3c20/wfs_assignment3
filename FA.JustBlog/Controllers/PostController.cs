using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FA.JustBlog.Controllers;

[Authorize]
public class PostController : BaseController
{
	public PostController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	// GET: PostController
	public ActionResult Index(string? search, int? page)
	{
		var posts = _unitOfWork.PostRepository.GetPublishedPosts();
		IEnumerable<Post> postsPaging;
		int pageSize = 5;
		if (!search.IsNullOrEmpty())
		{
			postsPaging =
				_unitOfWork.PostRepository.GetPaging(posts, p => p.Title.Contains(search), page ?? 1, pageSize);
		}
		else
		{
			postsPaging = _unitOfWork.PostRepository.GetPaging(posts, null, page ?? 1, pageSize);
		}

		var mostViewedPosts = _unitOfWork.PostRepository.GetAllPosts().OrderByDescending(p => p.ViewCount).Take(5);
		var latestPosts = _unitOfWork.PostRepository.GetLatestPost(5);
		var popularTags = _unitOfWork.TagRepository.GetAllTags().OrderByDescending(t => t.Count).Take(10);

		return View(new PostViewModel()
		{
			Posts = postsPaging,
			MostViewedPosts = mostViewedPosts,
			LatestPosts = latestPosts,
			PopularTags = popularTags,
			Page = page ?? 1,
			TotalPage = (int)Math.Ceiling((decimal)posts.Count / pageSize)
		});
	}

	// public ActionResult Detail(int id)
	// {
	// 	var post = _unitOfWork.PostRepository.FindPost(id);
	// 	return View(post);
	// }


	[Route("Post/{year}/{month}/{title}")]
	public ActionResult Detail(int year, int month, string title)
	{
		try
		{
			var post = _unitOfWork.PostRepository.Find(p =>
				p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == title).First();
			return View(post);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			return RedirectToAction("Error", "Home");
		}
	}

	[Route("Category/{category?}/{page?}")]
	public ActionResult PostsByCategory(string? category, int? page)
	{
		ViewBag.Category = category;
		var posts = _unitOfWork.PostRepository.GetPostsByCategory(category).Where(p => p.Published).ToList();
		int pageSize = 5;
		IEnumerable<Post> postsPaging = _unitOfWork.PostRepository.GetPaging(posts, null, page ?? 1, pageSize);
		// ReSharper disable once Mvc.InvalidModelType
		return View("Index",
			new PostViewModel()
			{
				Posts = postsPaging, 
				Page = page ?? 1,
				TotalPage = (int)Math.Ceiling((decimal)posts.Count / pageSize)
			});
	}
}