using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class CafeRepository(ApplicationDbContext dbContext) : Repository<Cafe>(dbContext), IRepository<Cafe>
	{
		ApplicationDbContext _dbContext = dbContext;

		public async Task<IEnumerable<Cafe>> GetCafesByLocationAsync(string location)
		{
			return await _dbContext.Cafes
				.Include(c => c.Employees)
				.Where(c => c.Location == location)
				.ToListAsync();
		}
	}
}
