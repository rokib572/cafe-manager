using Application.Commands.Employees;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Employees
{
	public class UpdateEmployeeHandler(IRepository<Employee> employeeRepository, IRepository<Cafe> cafeRepository) : IRequestHandler<UpdateEmployeeCommand, string>
	{
		private readonly IRepository<Employee> _employeeRepository = employeeRepository;
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<string> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
		{

			var employee = await _employeeRepository.GetByIdAsync(request.Id) ?? throw new Exception("Employee not found");
			_ = await _cafeRepository.GetByIdAsync(request.CafeId!) ?? throw new Exception("Invalid Cafe Id");

			employee.Name = request.Name;
			employee.EmailAddress = request.EmailAddress;
			employee.PhoneNumber = request.PhoneNumber;
			employee.Gender = request.Gender;
			employee.CafeId = new Guid(request.CafeId!);

			await _employeeRepository.UpdateAsync(employee);

			return employee.Id;
		}
	}
}
