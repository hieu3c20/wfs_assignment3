using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Core.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
	public CategoryRepository(JustBlogContext context) : base(context)
	{
		
	}

	public Category Find(int categoryId)
	{
		return GetById(categoryId);
	}

	public void AddCategory(Category category)
	{
		Create(category);
	}

	public void UpdateCategory(Category category)
	{
		Update(category);
	}

	public void DeleteCategory(Category category)
	{
		Delete(category);
	}

	public void DeleteCategory(int categoryId)
	{
		Delete(categoryId);
	}

	public IList<Category> GetAllCategories()
	{
		return GetAll().ToList();
	}
}