using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	public class Repository<T>(ApplicationDbContext dbContext) : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _dbContext = dbContext;

		public async Task<T?> GetByIdAsync(string id)
		{
			Guid guidOutput;
			bool isValid = Guid.TryParse(id, out guidOutput);

			return await _dbContext.Set<T>().FindAsync(isValid ? guidOutput : id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllWithIncludeAsync<U>(Expression<Func<T, object>> includes)
		{
			return await _dbContext.Set<T>().Include(includes).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllWithFilterIncludeAsync<U>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includes)
		{
			return await _dbContext.Set<T>().Include(includes).Where(predicate).ToListAsync();
		}

		public async Task AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Set<T>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
