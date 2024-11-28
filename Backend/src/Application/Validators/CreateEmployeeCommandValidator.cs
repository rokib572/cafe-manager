using Application.Commands.Employees;
using Core.Entities;
using FluentValidation;

namespace Application.Validators
{
	public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
	{
		public CreateEmployeeCommandValidator()
		{
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
				.NotEmpty().WithMessage("Cafe ID is required for the employee.")
				.When(e => e.CafeId != null);
		}
	}
}
