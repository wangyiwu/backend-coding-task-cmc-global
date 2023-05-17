using Application.Services;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace WebApiTest.ControllersTest;

public class PortControllerTest
{
    private readonly Mock<ILogger<PortController>> _mockLogger;
    private readonly Mock<IPortService> _mockPortService;

    private readonly PortController _portController;

    public PortControllerTest()
    {
        _mockLogger = new Mock<ILogger<PortController>>();
        _mockPortService = new Mock<IPortService>();

        _portController = new PortController(_mockLogger.Object, _mockPortService.Object);
    }

    [Fact]
    public void GetPorts_Returns_Ok()
    {
        // Arrange
        var listPorts = new List<Port>
        {
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude = 116,
                    Latitude =  20
                },
                Name = "Victoria Harbour",
            },
            new Port()
            {
                Id = Guid.NewGuid(),
                Position = new Position
                {
                    Longitude =112,
                    Latitude =   22
                },
                Name = "Aberdeen Harbour",
            }
        };

        _mockPortService.Setup(x => x.GetPorts()).ReturnsAsync(listPorts);

        // Act
        var result = _portController.GetPorts().Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }
}
