using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Cafe> Cafes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Employee Configuration
			modelBuilder.Entity<Employee>()
				.ToTable("Employees");

			modelBuilder.Entity<Employee>()
				.HasKey(e => e.Id);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Id)
				.HasMaxLength(11)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.Name)
				.HasMaxLength(100)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.EmailAddress)
				.HasMaxLength(150)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.PhoneNumber)
				.HasMaxLength(8)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.Gender)
				.HasMaxLength(6)
				.IsRequired();

			// Cafe Configuration
			modelBuilder.Entity<Cafe>()
				.ToTable("Cafe");

			modelBuilder.Entity<Cafe>()
				.HasKey(c => c.Id);

			modelBuilder.Entity<Cafe>()
				.Property(c => c.Name)
				.HasMaxLength(10)
				.IsRequired();

			modelBuilder.Entity<Cafe>()
				.Property(c => c.Description)
				.HasMaxLength(150)
				.IsRequired();

			modelBuilder.Entity<Cafe>()
				.Property(c => c.Location)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<Cafe>()
				.HasMany(e => e.Employees)
				.WithOne();
				
		}
	}
}
