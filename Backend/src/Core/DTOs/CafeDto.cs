namespace Core.DTOs
{
	public class CafeDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Employees { get; set; }
		public string Location { get; set; }
		public string? Logo { get; set; }
	}

	public class CafeWithEmployeeDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Employees { get; set; }
		public string Location { get; set; }
		public string? Logo { get; set; }
	}
}
