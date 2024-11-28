using Application.Commands.Cafes;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Cafes
{
	public class UpdateCafeHandler(IRepository<Cafe> cafeRepository) : IRequestHandler<UpdateCafeCommand, string>
	{
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;

		public async Task<string> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
		{
			var cafe = await _cafeRepository.GetByIdAsync(request.Id) ?? throw new Exception("Cafe not found");

			cafe.Name = request.Name;
			cafe.Description = request.Description;
			cafe.Location = request.Location;
			cafe.Logo = request.Logo;

			await _cafeRepository.UpdateAsync(cafe);

			return cafe.Id.ToString();
		}
	}
}
