using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DependencyInjection;
using API.Filters;

namespace API.Extensions
{
	public static class ServiceExtensions
	{
		public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
		{
			// Add FluentValidation
			services.AddFluentValidationAutoValidation();

			// Add Infrastructure Services
			services.AddInfrastructureServices(configuration.GetConnectionString("DefaultConnection")!);

			// Add Exception Filters
			services.AddMvc(options =>
			{
				options.Filters.Add<ExceptionFilter>();
			});
		}
	}
}