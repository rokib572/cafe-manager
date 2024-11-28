using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Cafes;
using Application.Queries.Cafes;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CafeController(IMediator mediator) : ControllerBase
	{
		private readonly IMediator _mediator = mediator;

		[HttpPost]
		public async Task<IActionResult> CreateCafe([FromBody] CreateCafeCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(CreateCafe), new { id = result }, result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCafe([FromBody] UpdateCafeCommand command)
		{
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCafe(string id)
		{
			await _mediator.Send(new DeleteCafeCommand { CafeId = id });
			return NoContent();
		}

		[HttpGet]
		public async Task<IActionResult> GetCafes([FromQuery] string? location)
		{
			var query = new GetCafesQuery { Location = location };
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("{cafeId}")]
		public async Task<IActionResult> GetCafeEmployees(string cafeId)
		{
			var query = new GetCafeEmployees { CafeId= cafeId };
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}