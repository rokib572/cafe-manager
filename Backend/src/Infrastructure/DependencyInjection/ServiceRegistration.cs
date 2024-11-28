using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IRepository<Cafe>, CafeRepository>();
			services.AddScoped<IRepository<Employee>, EmployeeRepository>();
		}
	}
}
