using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Models;

public class PostViewModel
{
	public IEnumerable<Post> Posts { get; set; }
	public IEnumerable<Post>? LatestPosts { get; set; }
	public IEnumerable<Post>? MostViewedPosts { get; set; }
	public IEnumerable<Tag>? PopularTags { get; set; }
	public int Page { get; set; }
	public int TotalPage { get; set; }
}