using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
	public static class DataSeeder
	{
		public static async Task SeedAsync(ApplicationDbContext dbContext)
		{
			// Ensure the database is created
			await dbContext.Database.EnsureCreatedAsync();

			// Load data from JSON file
			var seedDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData.json");
			if (!File.Exists(seedDataPath))
			{
				throw new FileNotFoundException("Seed data file not found", seedDataPath);
			}

			var seedDataJson = await File.ReadAllTextAsync(seedDataPath);
			var seedData = JsonSerializer.Deserialize<SeedData>(seedDataJson);

			// Seed Cafes
			if (seedData?.Cafes != null && !dbContext.Cafes.Any())
			{
				await dbContext.Cafes.AddRangeAsync(seedData.Cafes);
			}

			// Seed Employees
			if (seedData?.Employees != null && !dbContext.Employees.Any())
			{
				foreach (var employee in seedData.Employees)
				{
					employee.Id = GenerateUniqueEmployeeId(); // Generate unique IDs
				}
				await dbContext.Employees.AddRangeAsync(seedData.Employees);
			}

			// Save changes to the database
			await dbContext.SaveChangesAsync();
		}

		private static string GenerateUniqueEmployeeId()
		{
			var random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return "UI" + new string(Enumerable.Repeat(chars, 7)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}

	public class SeedData
	{
		public List<Cafe>? Cafes { get; set; }
		public List<Employee>? Employees { get; set; }
	}
}
