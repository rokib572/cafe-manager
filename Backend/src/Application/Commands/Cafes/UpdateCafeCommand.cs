using MediatR;

namespace Application.Commands.Cafes
{
	public class UpdateCafeCommand : IRequest<string>
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string? Logo { get; set; }
	}
}
