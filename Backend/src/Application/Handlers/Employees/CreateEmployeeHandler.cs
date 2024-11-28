using Application.Commands.Employees;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Employees
{
	public class CreateEmployeeHandler(IRepository<Employee> employeeRepository, IRepository<Cafe> cafeRepository) : IRequestHandler<CreateEmployeeCommand, string>
	{
		private readonly IRepository<Employee> _employeeRepository = employeeRepository;
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
		{
			_ = await _cafeRepository.GetByIdAsync(request.CafeId!) ?? throw new Exception("Invalid Cafe Id");

			var employee = new Employee
			{
				Name = request.Name,
				EmailAddress = request.EmailAddress,
				PhoneNumber = request.PhoneNumber,
				Gender = request.Gender,
				CafeId = new Guid(request.CafeId!),
				StartDate = DateTime.Now
			};

			await _employeeRepository.AddAsync(employee);
			return employee.Id;

		}
	}
}
