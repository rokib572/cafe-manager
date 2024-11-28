using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class EmployeeRepository(ApplicationDbContext dbContext) : Repository<Employee>(dbContext), IRepository<Employee>
	{
		private readonly ApplicationDbContext _dbContext = dbContext;

		public async Task<IEnumerable<Employee>> GetEmployeesByCafeAsync(string cafeId)
		{
			return await _dbContext.Employees
				.Where(e => e.CafeId.ToString() == cafeId)
				.ToListAsync();
		}

		public async Task<IEnumerable<Employee>> GetEmployeesSortedByDaysWorkedAsync()
		{
			return await _dbContext.Employees
				.OrderByDescending(e => EF.Functions.DateDiffDay(e.StartDate, DateTime.UtcNow))
				.ToListAsync();
		}

		public async Task<bool> EmployeeExistsByPhoneNumberAsync(string phoneNumber)
		{
			return await _dbContext.Employees
				.AnyAsync(e => e.PhoneNumber == phoneNumber);
		}

		public async Task<Employee?> GetEmployeeByIdAsync(string employeeId)
		{
			return await _dbContext.Employees
				.FirstOrDefaultAsync(e => e.Id == employeeId);
		}
	}
}

