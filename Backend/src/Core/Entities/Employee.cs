namespace Core.Entities
{
	public class Employee
	{
		public string Id { get; set; } = $"UI{Guid.NewGuid().ToString()[..8]}";
		public string Name { get; set; } = string.Empty;
		public string EmailAddress { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public Guid CafeId { get; set; }
		public DateTime StartDate { get; set; }
	}
}
