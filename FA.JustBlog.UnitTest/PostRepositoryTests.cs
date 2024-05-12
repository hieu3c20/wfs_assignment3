using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace TestProject1;

public class PostRepositoryTests
{
	private JustBlogContext _context;
	private IUnitOfWork _unitOfWork;
	private IPostRepository _postRepository;

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
		_postRepository = _unitOfWork.PostRepository;
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