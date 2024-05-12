using FA.JustBlog.Core.Models.Entities;
using Solution1.Data.Infrastructures;

namespace FA.JustBlog.Core.IRepositories;

public interface IPostRepository : IBaseRepository<Post>
{
	public Post FindPost(int year, int month, string urlSlug);
	public Post FindPost(int postId);
	public void AddPost(Post post);
	public void UpdatePost(Post post);
	public void DeletePost(Post post);
	public void DeletePost(int postId);
	public IList<Post> GetAllPosts();
	public IList<Post> GetPublishedPosts();
	public IList<Post> GetUnpublishedPosts();
	public IList<Post> GetLatestPost(int size);
	public IList<Post> GetPostsByMonth(DateTime monthYear);
	public int CountPostsForCategory(string category);
	public IList<Post> GetPostsByCategory(string category);
	public int CountPostsForTag(string tag);
	public IList<Post> GetPostsByTag(string tag);
}