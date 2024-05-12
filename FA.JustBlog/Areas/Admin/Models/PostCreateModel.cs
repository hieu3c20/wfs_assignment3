using System.ComponentModel.DataAnnotations;
using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Areas.Admin.Models;

public class PostCreateModel
{
	[Key]
	public int Id { get; set; }
	
	[Required(ErrorMessage = "Title is required!")]
	[StringLength(255, MinimumLength = 2, ErrorMessage = "Title must have more than 2 characters!")]
	public string? Title { get; set; }
	
	[Required(ErrorMessage = "Description is required!")]
	[StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Description must have more than 2 characters!")]
	public string? ShortDescription { get; set; }
	
	[Required(ErrorMessage = "Content is required!")]
	[StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Content must have more than 2 characters!")]
	public string? PostContent { get; set; }
	
	[Required(ErrorMessage = "Url slug is required!")]
	[RegularExpression(@"^[a-z0-9]+(?:-[a-z0-9]+)*$")]
	[StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Url slug must have more than 2 characters!")]
	public string? UrlSlug { get; set; }
	
	public int ViewCount { get; set; }
	
	public int RateCount { get; set; }
	
	public int TotalRate { get; set; }
	public int? CategoryId { get; set; }
	public ICollection<int>? TagIds { get; set; }
}