using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Employees;
using Application.Queries.Employees;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController(IMediator mediator) : ControllerBase
	{
		private readonly IMediator _mediator = mediator;

		[HttpPost]
		public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(CreateEmployee), new { id = result }, result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
		{
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployee(string id)
		{
			await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });
			return NoContent();
		}

		[HttpGet]
		public async Task<IActionResult> GetEmployees([FromQuery] string? cafeId)
		{
			var query = new GetEmployeesQuery { CafeId = cafeId };
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}