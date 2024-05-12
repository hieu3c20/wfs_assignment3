using FA.JustBlog.Core.Models.Entities;
using Solution1.Data.Infrastructures;

namespace FA.JustBlog.Core.IRepositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
	public Comment Find(int commentId);
	public void AddComment(Comment comment);
	public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
	public void UpdateComment(Comment comment);
	public void DeleteComment(Comment comment);
	public void DeleteComment(int commendId);
	public IList<Comment> GetAllComments();
	public IList<Comment> GetCommentsForPost(int postId);
	public IList<Comment> GetCommentsForPost(Post post);
}