using FA.JustBlog.Core.Models.Entities;
using FA.JustBlog.Core.Models.Entities;
using Solution1.Data.Infrastructures;

namespace FA.JustBlog.Core.IRepositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
	public Category Find(int categoryId);
	public void AddCategory(Category category);
	public void UpdateCategory(Category category);
	public void DeleteCategory(Category category);
	public void DeleteCategory(int categoryId);
	public IList<Category> GetAllCategories();
}