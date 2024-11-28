using Application.Queries.Cafes;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Cafes
{
	public class GetCafesEmployeeHandler(IRepository<Cafe> cafeRepository) : IRequestHandler<GetCafeEmployees, List<EmployeeDto>>
	{
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<List<EmployeeDto>> Handle(GetCafeEmployees request, CancellationToken cancellationToken)
		{
			var cafes = await _cafeRepository.GetAllWithFilterIncludeAsync<Cafe>(e => e.Id == new Guid(request.CafeId), i => i.Employees);

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
