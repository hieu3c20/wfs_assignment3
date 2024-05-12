using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace TestProject1;

public class CommentRepositoryTests
{
	private JustBlogContext _context;
	private IUnitOfWork _unitOfWork;
	private ICommentRepository _commentRepository;

	[SetUp]
	public void Setup()
	{
		DbContextOptions<JustBlogContext> options =
			new DbContextOptionsBuilder<JustBlogContext>()
				.UseInMemoryDatabase(databaseName: "TestDb")
				.Options;

		//_context = new JustBlogContext(options);
		//if (!_context.Database.EnsureCreated())
		//{
		//	// Seed Data
		//}

		_unitOfWork = new UnitOfWork(_context);
		_commentRepository = _unitOfWork.CommentRepository;
	}

	[Test]
	public void UnitTest()
	{
		Assert.Pass();
	}

	[TearDown]
	public void TearDown()
	{
		_context.Database.EnsureDeleted();
		_context.Dispose();
		_unitOfWork.Dispose();
	}
}