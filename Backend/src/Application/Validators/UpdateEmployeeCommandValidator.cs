using Application.Commands.Employees;
using FluentValidation;

namespace Application.Validators
{
	public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
	{
		public UpdateEmployeeCommandValidator()
		{
			RuleFor(e => e.Id)
				.NotEmpty().WithMessage("Employee ID is required.")
				.Length(3, 11).WithMessage("Employee ID must be exactly 9 characters long.");

			RuleFor(e => e.Name)
				.NotEmpty().WithMessage("Employee name is required.")
				.MinimumLength(6).WithMessage("Cafe name must be at least 6 characters.")
				.MaximumLength(10).WithMessage("Cafe name must not exceed 10 characters.");

			RuleFor(e => e.EmailAddress)
				.NotEmpty().WithMessage("Email address is required.")
				.EmailAddress().WithMessage("Invalid email format.")
				.MaximumLength(50).WithMessage("Email address must not exceed 50 characters.");

			RuleFor(e => e.PhoneNumber)
				.NotEmpty().WithMessage("Phone number is required.")
				.Matches(@"^[89]\d{7}$").WithMessage("Phone number must start with 8 or 9 and exactly 8 digits.");

			RuleFor(e => e.Gender)
				.NotEmpty().WithMessage("Gender is required.")
				.Must(g => g == "Male" || g == "Female").WithMessage("Gender must be either 'Male' or 'Female'.");

			RuleFor(e => e.CafeId)
				.NotEmpty().WithMessage("Cafe ID is required.")
				.Must(c => Guid.TryParse(c, out _)).WithMessage("Cafe ID must be a valid GUID.")
				.When(e => e.CafeId != null);
		}
	}
}
