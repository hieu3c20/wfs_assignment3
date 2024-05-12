using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestProject1;

public class CategoryRepositoryTests
{
	private JustBlogContext _context;
	private IUnitOfWork _unitOfWork;
	private ICategoryRepository _categoryRepository;

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
		_categoryRepository = _unitOfWork.CategoryRepository;
	}

	/// <summary>
	/// naming should follow this template: [UnitOfWork_StateUnderTest_ExpectedBehavior]
	/// </summary>
	[Test]
	public void Find_WhenInputIsValid_ReturnCategory()
	{
		var category = _categoryRepository.Find(1);
		var expectName = "Movies";
		
		Assert.That(category.Name, Is.EqualTo(expectName));
	}

	[Test]
	public void AddCategory_WhenInputIsValid_ReturnAddToDbSuccess()
	{
		var category4 = new Category()
		{
			Name = "Category 4",
			UrlSlug = "category-4",
			Description = "No description"
		};
		
		var category5 = new Category()
		{
			Name = "Category 5",
			UrlSlug = "category-5",
			Description = "No description"
		};

		_categoryRepository.AddCategory(category4);
		_categoryRepository.AddCategory(category5);
		var result = _unitOfWork.SaveChanges();

		Assert.That(result, Is.EqualTo(2));
	}

	[Test]
	public void UpdateCategory_WhenInputIsValid_ReturnUpdateToDbSuccess()
	{
		var category = new Category()
		{
			Id = 1,
			Description = "New description"
		};

		_categoryRepository.UpdateCategory(category);
		var result = _unitOfWork.SaveChanges();

		Assert.That(result, Is.EqualTo(1));
	}

	[Test]
	public void DeleteCategory_WhenInputIsValid_ReturnDeleteToDbSuccess()
	{
		var category = _categoryRepository.Find(c => c.Name == "Category 4").First();
		_categoryRepository.DeleteCategory(category);
		var result = _unitOfWork.SaveChanges();
		
		Assert.That(result, Is.EqualTo(1));
	}
	
	[Test]
	public void DeleteCategoryById_WhenInputIsValid_ReturnDeleteToDbSuccess()
	{
		var category = _categoryRepository.Find(c => c.Name == "Category 5").First();
		_categoryRepository.DeleteCategory(category.Id);
		var result = _unitOfWork.SaveChanges();
		
		Assert.That(result, Is.EqualTo(1));
	}
	
	[Test]
	public void GetAllCategories_Ordinary_ReturnAll()
	{
		var categories = _categoryRepository.GetAllCategories();
		var expected = 3;
		
		Assert.That(expected, Is.EqualTo(categories.ToList().Count));
	}

	[TearDown]
	public void TearDown()
	{
		_context.Database.EnsureDeleted();
		_context.Dispose();
		_unitOfWork.Dispose();
	}
}