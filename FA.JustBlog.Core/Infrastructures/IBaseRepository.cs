﻿namespace Solution1.Data.Infrastructures
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Change state of entity to added
		/// </summary>
		/// <param name="entity"></param>
		void Create(TEntity entity);

		/// <summary>
		///  Change state of entities to added
		/// </summary>
		/// <param name="entities"></param>
		void CreateRange(List<TEntity> entities);

		/// <summary>
		/// Change state of entity to deleted
		/// </summary>
		/// <param name="entity"></param>
		void Delete(TEntity entity);

		/// <summary>
		/// Change state of entity to deleted
		/// </summary>
		/// <param name="entity"></param>
		void Delete(params object[] ids);


		/// <summary>
		/// Change state of entity to modified
		/// </summary>
		/// <param name="entity"></param>
		void Update(TEntity entity);

		/// <summary>
		/// Change state of entities to modified
		/// </summary>
		/// <param name="entity"></param>
		void UpdateRange(List<TEntity> entities);

		/// <summary>
		/// Get all <paramref name="TEntity"></paramref> from database
		/// </summary>
		/// <returns></returns>
		IEnumerable<TEntity> GetAll();

		TEntity GetById(params object[] primaryKey);

		IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

		IEnumerable<TEntity> GetPaging(IEnumerable<TEntity> orderBy, 
			Func<TEntity, bool>? predicate = null,
			int currentPage = 1,
			int pageSize = 10);
	}
}