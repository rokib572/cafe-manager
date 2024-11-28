using Application.Queries.Cafes;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Cafes
{
	public class GetCafesHandler(IRepository<Cafe> cafeRepository) : IRequestHandler<GetCafesQuery, List<CafeDto>>
	{
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<List<CafeDto>> Handle(GetCafesQuery request, CancellationToken cancellationToken)
		{
			var cafes = string.IsNullOrEmpty(request.Location) 
				? await _cafeRepository.GetAllWithIncludeAsync<Cafe>(x => x.Employees) 
				: await _cafeRepository.GetAllWithFilterIncludeAsync<Cafe>(e => e.Location == request.Location, i => i.Employees);

			return cafes.Select(c => new CafeDto
			{
				Id = c.Id.ToString(),
				Name = c.Name,
				Description = c.Description,
				Location = c.Location,
				Employees = c.Employees.Count,
				Logo = c.Logo
			}).ToList();
		}
	}
}
