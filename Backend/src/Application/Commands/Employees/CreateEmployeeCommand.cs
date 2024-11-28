using MediatR;

namespace Application.Commands.Employees
{
	public class CreateEmployeeCommand : IRequest<string>
	{
		public string Name { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public string? CafeId { get; set; }
	}
}
