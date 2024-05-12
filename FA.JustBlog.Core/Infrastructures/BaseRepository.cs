using FA.JustBlog.Core.Data;
using Microsoft.EntityFrameworkCore;
using Solution1.Data.Infrastructures;

namespace FA.JustBlog.Core.Infrastructures;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	protected readonly JustBlogContext Context;
	protected DbSet<TEntity> DbSet;

	public BaseRepository(JustBlogContext context)
	{
		Context = context;
		DbSet = context.Set<TEntity>();
	}

	public void Create(TEntity entity)
	{
		DbSet.Add(entity);
	}

	public void CreateRange(List<TEntity> entities)
	{
		DbSet.AddRange(entities);
	}

	public void Delete(TEntity entity)
	{
		DbSet.Remove(entity);
	}

	public void Delete(params object[] ids)
	{
		var entity = DbSet.Find(ids);
		if (entity == null)
			throw new ArgumentException($"{string.Join(";", ids)} not exist in the {typeof(TEntity).Name} table");
		DbSet.Remove(entity);
	}

	public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
	{
		return DbSet.Where(predicate);
	}

	public IEnumerable<TEntity> GetAll()
	{
		return DbSet;
	}

	public TEntity GetById(params object[] primaryKey)
	{
		return DbSet.Find(primaryKey);
	}

	public IEnumerable<TEntity> GetPaging(IEnumerable<TEntity> orderBy,
		Func<TEntity, bool>? predicate = null, 
		int currentPage = 1,
		int pageSize = 10)
	{
		var skipCount = (currentPage - 1) * pageSize;

		IEnumerable<TEntity> results;
		if (predicate != null)
		{
			results = orderBy.Where(predicate).Skip(skipCount).Take(pageSize);
		}
		else
		{
			results = orderBy.Skip(skipCount).Take(pageSize);
		}

		return results;
	}


	public void Update(TEntity entity)
	{
		DbSet.Update(entity);
	}

	public void UpdateRange(List<TEntity> entities)
	{
		DbSet.UpdateRange(entities);
	}
}