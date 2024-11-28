using MediatR;

namespace Application.Commands.Employees
{
	public class UpdateEmployeeCommand : IRequest<string>
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public string? CafeId { get; set; }
		public DateTime StartDate { get; set; }
	}
}
