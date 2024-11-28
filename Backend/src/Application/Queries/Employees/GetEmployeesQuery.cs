using Core.DTOs;
using MediatR;

namespace Application.Queries.Employees
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDto>>
    {
        public string? CafeId { get; set; }
    }
}
