using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Core.Repositories;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
	public CommentRepository(JustBlogContext context) : base(context)
	{
	}

	public Comment Find(int commentId)
	{
		return GetById(commentId);
	}

	public void AddComment(Comment comment)
	{
		Create(comment);
	}

	public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
	{
		Create(new Comment()
		{
			Name = commentName,
			Email = commentEmail,
			PostId = postId,
			CommentHeader = commentTitle,
			CommentText = commentBody,
			CommentTime = DateTime.Now,
		});
	}

	public void UpdateComment(Comment comment)
	{
		Update(comment);
	}

	public void DeleteComment(Comment comment)
	{
		Delete(comment);
	}

	public void DeleteComment(int commendId)
	{
		Delete(commendId);
	}

	public IList<Comment> GetAllComments()
	{
		return GetAll().ToList();
	}

	public IList<Comment> GetCommentsForPost(int postId)
	{
		return Find(comment => comment.PostId == postId).ToList();
	}

	public IList<Comment> GetCommentsForPost(Post post)
	{
		return Find(comment => comment.Post == post).ToList();
	}
}