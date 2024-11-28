using Application.Queries.Employees;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Employees
{
	public class GetEmployeesHandler(IRepository<Cafe> cafeRepository) : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
	{
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
		{
			var query = _cafeRepository.GetAllWithIncludeAsync<Employee>(x => x.Employees).Result.AsQueryable();

			if (!string.IsNullOrEmpty(request.CafeId))
			{
				query = query.Where(e => e.Id == new Guid(request.CafeId));
			}

			var cafes = query.ToList();

			return [.. cafes.SelectMany(e => e.Employees, (cafe, employee) => new EmployeeDto()
			{
				Id = employee.Id,
				Name = employee.Name,
				EmailAddress = employee.EmailAddress,
				PhoneNumber = employee.PhoneNumber,
				Gender = employee.Gender,
				DaysWorked = (int)(DateTime.Now - employee.StartDate).TotalDays,
				Cafe = cafe.Name,
				CafeId = cafe.Id.ToString()
			}).OrderByDescending(e => e.DaysWorked)];
		}
	}
}
