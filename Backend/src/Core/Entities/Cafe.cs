﻿namespace Core.Entities
{
	public class Cafe
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? Logo { get; set; }
		public string Location { get; set; } = string.Empty;
		public ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}
