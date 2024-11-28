using FluentValidation;
using Application.Commands.Cafes;

namespace Application.Validators
{
	public class CreateCafeCommandValidator : AbstractValidator<CreateCafeCommand>
	{
		public CreateCafeCommandValidator()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("Cafe name is required.")
				.MinimumLength(6).WithMessage("Cafe name must be at least 6 characters.")
				.MaximumLength(10).WithMessage("Cafe name must not exceed 10 characters.");

			RuleFor(c => c.Description)
				.NotEmpty().WithMessage("Description is required.")
				.MaximumLength(256).WithMessage("Description must not exceed 150 characters.");

			RuleFor(c => c.Location)
				.NotEmpty().WithMessage("Location is required.")
				.MaximumLength(150).WithMessage("Location must not exceed 150 characters.");

			RuleFor(c => c.Logo)
				.MaximumLength(256).WithMessage("Logo URL must not exceed 256 characters.")
				.When(c => !string.IsNullOrEmpty(c.Logo));
		}
	}
}
