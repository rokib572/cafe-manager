using Application.Commands.Cafes;
using FluentValidation;

namespace Application.Validators
{
	public class DeleteCafeCommandValidator : AbstractValidator<DeleteCafeCommand>
	{
		public DeleteCafeCommandValidator()
		{
			RuleFor(c => c.CafeId)
				.NotEmpty().WithMessage("Cafe ID is required.")
				.Must(id => Guid.TryParse(id, out _)).WithMessage("Cafe ID must be a valid GUID.");
		}
	}
}
