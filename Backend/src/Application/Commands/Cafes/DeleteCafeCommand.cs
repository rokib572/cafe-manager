using MediatR;

namespace Application.Commands.Cafes
{
	public class DeleteCafeCommand : IRequest<string>
	{
		public string CafeId { get; set; }
	}
}
