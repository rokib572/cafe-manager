using Core.DTOs;
using MediatR;

namespace Application.Queries.Cafes
{
	public class GetCafeEmployees : IRequest<List<EmployeeDto>>
	{
		public string CafeId { get; set; }
	}
}
