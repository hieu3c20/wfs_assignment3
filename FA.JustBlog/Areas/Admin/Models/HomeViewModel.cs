namespace FA.JustBlog.Areas.Admin.Models;

public class HomeViewModel
{
	public int TotalPosts { get; set; }
	public int TotalCategories { get; set; }
	public int TotalTags { get; set; }
	public int TotalComments { get; set; }
	public IEnumerable<int>? Years { get; set; }
	public IEnumerable<int>? TotalPostsOverYears { get; set; }
	public IEnumerable<string>? CategoryNames { get; set; }
	public IEnumerable<int>? TotalPostsPerCategories { get; set; }
}