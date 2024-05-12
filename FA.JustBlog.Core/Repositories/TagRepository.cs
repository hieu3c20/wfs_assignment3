using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models.Entities;

namespace FA.JustBlog.Core.Repositories;

public class TagRepository : BaseRepository<Tag>, ITagRepository
{
	public TagRepository(JustBlogContext context) : base(context)
	{
		
	}
	public Tag Find(int tagId)
	{
		return GetById(tagId);
	}

	public void AddTag(Tag tag)
	{
		Create(tag);
	}

	public void UpdateTag(Tag tag)
	{
		Update(tag);
	}

	public void DeleteTag(Tag tag)
	{
		Delete(tag);
	}

	public void DeleteTag(int tagId)
	{
		Delete(tagId);
	}

	public IList<Tag> GetAllTags()
	{
		return GetAll().ToList();
	}

	public Tag GetTagByUrlSlug(string urlSlug)
	{
		return Find(tag => tag.UrlSlug.Contains(urlSlug)).First();
	}
}