using Application.Commands.Employees;
using FluentValidation;

namespace Application.Validators
{
	public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
	{
		public DeleteEmployeeCommandValidator()
		{
			RuleFor(e => e.EmployeeId)
				.NotEmpty().WithMessage("Employee ID is required.")
				.Length(3, 11).WithMessage("Employee ID must be exactly 11 characters long.");
		}
	}
}
