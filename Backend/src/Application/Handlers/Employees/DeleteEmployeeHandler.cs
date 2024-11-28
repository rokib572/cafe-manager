using Application.Commands.Employees;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Employees
{
	public class DeleteEmployeeHandler(IRepository<Employee> employeeRepository) : IRequestHandler<DeleteEmployeeCommand, string>
	{
		private readonly IRepository<Employee> _employeeRepository = employeeRepository;

		public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
		{
			var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId!) ?? throw new Exception("Employee not found");
			await _employeeRepository.DeleteAsync(employee);
			return employee.Id;
		}
	}
}
