using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private ICategoryRepository? _categoryRepository;
        private IPostRepository? _postRepository;
        private ITagRepository? _tagRepository;
        private ICommentRepository? _commentRepository;

        public UnitOfWork(JustBlogContext context)
        {
            _context = context;
        }
        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context)); }
        }
        public IPostRepository PostRepository
        {
            get { return _postRepository ?? (_postRepository = new PostRepository(_context)); }
        }
        public ITagRepository TagRepository
        {
            get { return _tagRepository ?? (_tagRepository = new TagRepository(_context)); }
        }

        public ICommentRepository CommentRepository
        {
            get { return _commentRepository ?? (_commentRepository = new CommentRepository(_context)); }
        }

        public JustBlogContext JustBlogContext => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
