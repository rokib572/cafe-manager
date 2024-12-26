using API.Controllers;
using Application.Commands.Cafes;
using Application.Queries.Cafes;
using Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CafeManagerTests
{
	[TestFixture]
	public class CafeControllerTests
	{
		private Mock<IMediator> _mockMediator;
		private CafeController _controller;

		[SetUp]
		public void Setup()
		{
			_mockMediator = new Mock<IMediator>();
			_controller = new CafeController(_mockMediator.Object);
		}

		[Test]
		public async Task CreateCafe_ReturnsCreatedAtActionResult_WithId()
		{
			var command = new CreateCafeCommand { Name = "Cafe Alpha", Location = "NY", Description = "Cozy cafe" };
			var newCafeId = Guid.NewGuid();
			_mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync(newCafeId.ToString());

			var result = await _controller.CreateCafe(command);

			var createdAtActionResult = result as CreatedAtActionResult;
			Assert.That(createdAtActionResult, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(201));
				Assert.That(createdAtActionResult.Value, Is.EqualTo(newCafeId.ToString()));
			});
		}

		[Test]
		public async Task UpdateCafe_ReturnsNoContentResult()
		{
			var command = new UpdateCafeCommand
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Updated Cafe",
				Description = "Modern cafe",
				Location = "LA",
				Logo = "updated-logo.png"
			};
			var updatedCafeId = command.Id;

			_mockMediator.Setup(m => m.Send(It.IsAny<UpdateCafeCommand>(), default))
						 .ReturnsAsync(updatedCafeId);

			var result = await _controller.UpdateCafe(command);

			var noContentResult = result as NoContentResult;
			Assert.That(noContentResult, Is.Not.Null);
			Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
		}

		[Test]
		public async Task DeleteCafe_ReturnsNoContentResult()
		{
			var command = new DeleteCafeCommand
			{
				CafeId = Guid.NewGuid().ToString()
			};

			var deletedCafeId = command.CafeId;


			_mockMediator.Setup(m => m.Send(It.IsAny<DeleteCafeCommand>(), default))
						 .ReturnsAsync(deletedCafeId);

			var result = await _controller.DeleteCafe(command.CafeId);

			var noContentResult = result as NoContentResult;
			Assert.That(noContentResult, Is.Not.Null);
			Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
		}

		[Test]
		public async Task GetCafes_ReturnsOkObjectResult_WithCafes()
		{
			var cafes = new List<CafeDto>
				{
					new() {
						Id = Guid.NewGuid().ToString(),
						Name = "Cafe Alpha",
						Description = "Cozy cafe",
						Location = "NY",
						Employees = 10,
						Logo = "logo1.png"
					},
					new() {
						Id = Guid.NewGuid().ToString(),
						Name = "Cafe Beta",
						Description = "Modern cafe",
						Location = "LA",
						Employees = 5,
						Logo = "logo2.png"
					}
				};

			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetCafesQuery>(), default))
				.ReturnsAsync(cafes);

			var result = await _controller.GetCafes(null);

			var okResult = result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(okResult.StatusCode, Is.EqualTo(200));
				Assert.That(okResult.Value, Is.EqualTo(cafes));
			});
		}

		[Test]
		public async Task GetCafeEmployees_ReturnsOkObjectResult_WithEmployees()
		{
			var cafeId = Guid.NewGuid().ToString();
			var employees = new List<EmployeeDto>
				{
					new() { Id = Guid.NewGuid().ToString(), Name = "Alice" },
					new() { Id = Guid.NewGuid().ToString(), Name = "Bob" }
				};

			_mockMediator.Setup(m => m.Send(It.IsAny<GetCafeEmployees>(), default))
						 .ReturnsAsync(employees);

			var result = await _controller.GetCafeEmployees(cafeId);

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
