using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.IRepositories;

namespace FA.JustBlog.Core.Infrastructures
{
	public interface IUnitOfWork : IDisposable
	{
		public ICategoryRepository CategoryRepository { get; }
		public IPostRepository PostRepository { get; }
		public ITagRepository TagRepository { get; }
		public ICommentRepository CommentRepository { get; }
		public JustBlogContext JustBlogContext { get; }
		int SaveChanges();
	}
}