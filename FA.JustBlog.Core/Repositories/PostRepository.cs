using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Core.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
	public PostRepository(JustBlogContext context) : base(context)
	{
	}

	public Post FindPost(int year, int month, string urlSlug)
	{
		return Find(post => 
			post.PostedOn.Year == year && 
			post.PostedOn.Month == month && 
			post.UrlSlug.Contains(urlSlug)).ToList()[0];
	}

	public Post FindPost(int postId)
	{
		return GetById(postId);
	}

	public void AddPost(Post post)
	{
		Create(post);
	}

	public void UpdatePost(Post post)
	{
		Update(post);
	}

	public void DeletePost(Post post)
	{
		Delete(post);
	}

	public void DeletePost(int postId)
	{
		Delete(postId);
	}

	public IList<Post> GetAllPosts()
	{
		return GetAll().ToList();
	}

	public IList<Post> GetPublishedPosts()
	{
		return Find(post => post.Published).ToList();
	}

	public IList<Post> GetUnpublishedPosts()
	{
		return Find(post => !post.Published).ToList();
	}

	public IList<Post> GetLatestPost(int size)
	{
		return GetAll().OrderByDescending(p => p.PostedOn).Take(size).ToList();
	}

	public IList<Post> GetPostsByMonth(DateTime monthYear)
	{
		return Find(post => post.PostedOn.Month == monthYear.Month).ToList();
	}

	public int CountPostsForCategory(string category)
	{
		return Find(post => post.Category.Name == category).Count();
	}

	public IList<Post> GetPostsByCategory(string category)
	{
		return Find(post => post.Category.Name == category).ToList();
	}

	public int CountPostsForTag(string tag)
	{
		return GetPostsByTag(tag).Count;
	}

	public IList<Post> GetPostsByTag(string tag)
	{
		return Find(post => post.PostTagMaps.Any(ptm => ptm.Tag.Name == tag)).ToList();
	}
}