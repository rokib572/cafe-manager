using Core.DTOs;
using MediatR;

namespace Application.Queries.Cafes
{
	public class GetCafesQuery : IRequest<List<CafeDto>>
	{
		public string? Location { get; set; }
	}
}
