using AutoMapper;
using FA.JustBlog.Areas.Admin.Models;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : BaseController
{
    public HomeController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(unitOfWork, mapper, userManager)
    {
    }
    
    // GET: AdminController
    [Route("Admin")]
    public ActionResult Index()
    {
        return View(new HomeViewModel()
        {
            TotalPosts = _unitOfWork.PostRepository.GetAllPosts().Count,
            TotalCategories = _unitOfWork.CategoryRepository.GetAllCategories().Count,
            TotalTags = _unitOfWork.TagRepository.GetAllTags().Count,
            TotalComments = _unitOfWork.CommentRepository.GetAllComments().Count,
            Years = _unitOfWork.PostRepository.GetAllPosts().OrderBy(p => p.PostedOn.Year).Select(p => p.PostedOn.Year).Distinct(),
            TotalPostsOverYears = _unitOfWork.PostRepository.GetAllPosts().OrderBy(p => p.PostedOn.Year).GroupBy(p => p.PostedOn.Year).Select(group => group.Count()),
            CategoryNames = _unitOfWork.CategoryRepository.GetAllCategories().OrderBy(c => c.Id).Select(c => c.Name),
            TotalPostsPerCategories = _unitOfWork.CategoryRepository.GetAllCategories().OrderBy(c => c.Posts.Count()).Select(c => c.Posts.Count())
        });
    }
}