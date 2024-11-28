using Application.Commands.Cafes;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.Cafes
{
	public class DeleteCafeHandler(IRepository<Cafe> cafeRepository, IRepository<Employee> employeeRepository) : IRequestHandler<DeleteCafeCommand, string>
	{
		private readonly IRepository<Cafe> _cafeRepository = cafeRepository;
		private readonly IRepository<Employee> _employeeRepository = employeeRepository;

		public async Task<string> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
		{
			var cafe = await _cafeRepository.GetByIdAsync(request.CafeId) ?? throw new Exception("Cafe not found");

			await _cafeRepository.DeleteAsync(cafe);

			return cafe.Id.ToString();
		}
	}
}
