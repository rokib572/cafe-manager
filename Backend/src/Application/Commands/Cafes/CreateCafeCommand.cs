using MediatR;

namespace Application.Commands.Cafes
{
	public class CreateCafeCommand : IRequest<string>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string? Logo { get; set; }
	}
}
