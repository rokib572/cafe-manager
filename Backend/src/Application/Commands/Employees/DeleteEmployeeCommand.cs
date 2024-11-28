using MediatR;

namespace Application.Commands.Employees
{
	public class DeleteEmployeeCommand : IRequest<string>
	{
		public string EmployeeId { get; set; }
	}
}
