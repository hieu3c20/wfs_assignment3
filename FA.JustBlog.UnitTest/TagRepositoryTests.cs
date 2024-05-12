using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestProject1;

public class TagRepositoryTests
{
	private JustBlogContext _context;
	private IUnitOfWork _unitOfWork;
	private ITagRepository _tagRepository;

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
		_tagRepository = _unitOfWork.TagRepository;
	}

	/// <summary>
	/// naming should follow this template: [UnitOfWork_StateUnderTest_ExpectedBehavior]
	/// </summary>
	[Test]
	public void Find_WhenInputIsValid_ReturnTag()
	{
		var tag = _tagRepository.Find(1);
		var expectName = "CR7";
		
		Assert.That(tag.Name, Is.EqualTo(expectName));
	}

	[Test]
	public void AddTag_WhenInputIsValid_ReturnAddToDbSuccess()
	{
		var tag4 = new Tag()
		{
			Name = "Tag 4",
			UrlSlug = "tag-4",
			Description = "No description"
		};
		
		var tag5 = new Tag()
		{
			Name = "Tag 5",
			UrlSlug = "tag-5",
			Description = "No description"
		};

		_tagRepository.AddTag(tag4);
		_tagRepository.AddTag(tag5);
		var result = _unitOfWork.SaveChanges();

		Assert.That(result, Is.EqualTo(2));
	}

	[Test]
	public void UpdateTag_WhenInputIsValid_ReturnUpdateToDbSuccess()
	{
		var tag = new Tag()
		{
			Id = 1,
			Description = "New description"
		};

		_tagRepository.UpdateTag(tag);
		var result = _unitOfWork.SaveChanges();

		Assert.That(result, Is.EqualTo(1));
	}

	[Test]
	public void DeleteTag_WhenInputIsValid_ReturnDeleteToDbSuccess()
	{
		var tag = _tagRepository.Find(c => c.Name == "Tag 4").First();
		_tagRepository.DeleteTag(tag);
		var result = _unitOfWork.SaveChanges();
		
		Assert.That(result, Is.EqualTo(1));
	}
	
	[Test]
	public void DeleteTagById_WhenInputIsValid_ReturnDeleteToDbSuccess()
	{
		var tag = _tagRepository.Find(c => c.Name == "Tag 5").First();
		_tagRepository.DeleteTag(tag.Id);
		var result = _unitOfWork.SaveChanges();
		
		Assert.That(result, Is.EqualTo(1));
	}
	
	[Test]
	public void GetAllTags_Ordinary_ReturnAll()
	{
		var categories = _tagRepository.GetAllTags();
		var expected = 3;
		
		Assert.That(expected, Is.EqualTo(categories.ToList().Count));
	}
	
	[Test]
	public void GetTagByUrlSlug_Ordinary_ReturnAll()
	{
		var urlSlug = "lionel-messi";
		var tags = _tagRepository.GetTagByUrlSlug(urlSlug);
		var expectedName = "Messi";
		
		Assert.That(expectedName, Is.EqualTo(tags.Name));
	}

	[TearDown]
	public void TearDown()
	{
		_context.Database.EnsureDeleted();
		_context.Dispose();
		_unitOfWork.Dispose();
	}
}