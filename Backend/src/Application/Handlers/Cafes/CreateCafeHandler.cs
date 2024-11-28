using Application.Commands.Cafes;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Cafes
{
	public class CreateCafeHandler(IRepository<Cafe> cafeRepository) : IRequestHandler<CreateCafeCommand, string>
	{
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<string> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
		{
			var cafe = new Cafe
			{
				Name = request.Name,
				Description = request.Description,
				Location = request.Location,
				Logo = request.Logo
			};

			await _cafeRepository.AddAsync(cafe);
			return cafe.Id.ToString();
		}
	}
}
