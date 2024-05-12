using FA.JustBlog.Core.Models.Entities;
using Solution1.Data.Infrastructures;

namespace FA.JustBlog.Core.IRepositories;

public interface ITagRepository : IBaseRepository<Tag>
{
	public Tag Find(int tagId);
	public void AddTag(Tag tag);
	public void UpdateTag(Tag tag);
	public void DeleteTag(Tag tag);
	public void DeleteTag(int tagId);
	public IList<Tag> GetAllTags();
	public Tag GetTagByUrlSlug(string urlSlug);

}