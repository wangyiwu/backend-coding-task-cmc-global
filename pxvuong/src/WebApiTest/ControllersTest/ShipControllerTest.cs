using Application.Models.RequestModel.Ship;
using Application.Services;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Porter.Controllers;
using Xunit;

namespace WebApiTest.ControllersTest;

public class ShipControllerTest
{
    private readonly Mock<ILogger<ShipController>> _mockLogger;
    private readonly Mock<IShipService> _mockShipService;

    private readonly ShipController _shipController;

    public ShipControllerTest()
    {
        _mockLogger = new Mock<ILogger<ShipController>>();
        _mockShipService = new Mock<IShipService>();

        _shipController = new ShipController(_mockLogger.Object, _mockShipService.Object);
    }

    [Fact]
    public void CreateShip_Returns_Ok()
    {
        // Arrange - no need

        // Act
        var result = _shipController
            .CreateShip(It.IsAny<CreateShipRequest>())
            .Result;

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [InlineData("bf206904-88c4-4596-9faa-73d843a46936")]
    [Theory]
    public void UpdateVelocity_Returns_Ok(string id)
    {
        // Arrange

        // Act
        var result = _shipController
            .UpdateVelocity(id, It.IsAny<UpdateVelocityRequest>())
            .Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    [InlineData(null)]
    [InlineData("")]
    [Theory]
    public void UpdateVelocity_Returns_BadRequest(string id)
    {
        // Arrange

        // Act
        var result = _shipController
            .UpdateVelocity(id, It.IsAny<UpdateVelocityRequest>())
            .Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<BadRequestResult>();
    }

    [InlineData("")]
    [InlineData("Ship 1")]
    [Theory]
    public void ClosestPort_Returns_Ok(string name)
    {
        // Arrange

        // Act
        var result = _shipController
            .ClosestPort(name)
            .Result;

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}
