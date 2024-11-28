using Application.Commands.Cafes;
using FluentValidation;

namespace Application.Validators
{
	public class UpdateCafeCommandValidator : AbstractValidator<UpdateCafeCommand>
	{
		public UpdateCafeCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEmpty().WithMessage("Cafe ID is required.")
				.Must(id => Guid.TryParse(id, out _)).WithMessage("Cafe ID must be a valid GUID.");

			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("Cafe name is required.")
				.MinimumLength(6).WithMessage("Cafe name must be at least 6 characters.")
				.MaximumLength(10).WithMessage("Cafe name must not exceed 10 characters.");

			RuleFor(c => c.Description)
				.NotEmpty().WithMessage("Description is required.")
				.MaximumLength(150).WithMessage("Description must not exceed 150 characters.");

			RuleFor(c => c.Location)
				.NotEmpty().WithMessage("Location is required.")
				.MaximumLength(50).WithMessage("Location must not exceed 50 characters.");

			RuleFor(c => c.Logo)
				.MaximumLength(256).WithMessage("Logo URL must not exceed 256 characters.")
				.When(c => !string.IsNullOrEmpty(c.Logo));
		}
	}
}
