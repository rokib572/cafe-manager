using API.Controllers;
using Application.Commands.Employees;
using Application.Queries.Employees;
using Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CafeManagerTests
{
	[TestFixture]
	public class EmployeeControllerTest
	{
		private Mock<IMediator> _mockMediator;
		private EmployeeController _controller;

		[SetUp]
		public void Setup()
		{
			_mockMediator = new Mock<IMediator>();
			_controller = new EmployeeController(_mockMediator.Object);
		}

		[Test]
		public async Task CreateEmployee_ReturnsCreatedAtActionResult_WithId()
		{
			var command = new CreateEmployeeCommand { Name = "Test Emp", EmailAddress = "abc@test.com", Gender = "Male" };
			var newEmployeeId = Guid.NewGuid();
			_mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync(newEmployeeId.ToString());

			var result = await _controller.CreateEmployee(command);

			var createdAtActionResult = result as CreatedAtActionResult;
			Assert.That(createdAtActionResult, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(201));
				Assert.That(createdAtActionResult.Value, Is.EqualTo(newEmployeeId.ToString()));
			});
		}

		[Test]
		public async Task UpdateEmplyee_ReturnsNoResultContent ()
		{
			var command = new UpdateEmployeeCommand { EmailAddress = "abc1@test.com", Gender = "Female", Name = "Test Emp" };
			var updatedEmployeeId = Guid.NewGuid().ToString();
			_mockMediator.Setup(m => m.Send(It.IsAny<UpdateEmployeeCommand>(), default))
						 .ReturnsAsync(updatedEmployeeId);

			var result = await _controller.UpdateEmployee(command);

			var noContentResult = result as NoContentResult;
			Assert.That(noContentResult, Is.Not.Null);
			Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
		}

		[Test]
		public async Task DeleteEmployee_ReturnsNoContentResult()
		{
			var command = new DeleteEmployeeCommand { EmployeeId = Guid.NewGuid().ToString() };
			var deletedCommandId = command.EmployeeId;
			_mockMediator.Setup(m => m.Send(It.IsAny<DeleteEmployeeCommand>(), default))
				.ReturnsAsync(deletedCommandId);

			var result = await _controller.DeleteEmployee(command.EmployeeId);

			var noContentResult = result as NoContentResult;
			Assert.That(noContentResult, Is.Not.Null);
			Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
		}

		[Test]
		public async Task GetEmployees_WithOkObjectResult_WithEmployees()
		{
			var employees = new List<EmployeeDto> 
			{ new()
				{
					Id = Guid.NewGuid().ToString(),
					CafeId = Guid.NewGuid().ToString(),
					EmailAddress = "cafe1@mail.com",
					DaysWorked = 15,
					Gender = "Male",
					Name = "Test Emp",
					PhoneNumber = "89512457"
				},
				new()
				{
					Id = Guid.NewGuid().ToString(),
					CafeId = Guid.NewGuid().ToString(),
					EmailAddress = "cafe2@mail.com",
					DaysWorked = 35,
					Gender = "Female",
					Name = "Test Emp2",
					PhoneNumber = "99512457"
				}
			};

			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetEmployeesQuery>(), default))
				.ReturnsAsync(employees);

			var result = await _controller.GetEmployees(null);

			var okResult = result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(okResult.StatusCode, Is.EqualTo(200));
				Assert.That(okResult.Value, Is.EqualTo(employees));
			});
		}
	}
}
