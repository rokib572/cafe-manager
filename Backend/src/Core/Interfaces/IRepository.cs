using System.Linq.Expressions;

namespace Core.Interfaces
{
	public interface IRepository<T> where T : class
	{
		Task<T?> GetByIdAsync(string id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllWithIncludeAsync<U>(Expression<Func<T, object>> includes);
		Task<IEnumerable<T>> GetAllWithFilterIncludeAsync<U>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includes);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
