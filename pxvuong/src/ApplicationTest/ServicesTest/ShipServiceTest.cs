using Application.Models.Dto.Ship;
using Application.Models.RequestModel.Ship;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using FluentAssertions;
using Moq;
using System.Collections.Concurrent;
using Xunit;

namespace ApplicationTest.ServicesTest;

public class ShipServiceTest
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IRepositoryFactory> _mockRepositoryFactory;
    private readonly ShipService _shipService;

    public ShipServiceTest()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepositoryFactory = new Mock<IRepositoryFactory>();

        _shipService = new ShipService(_mockRepositoryFactory.Object, _mockMapper.Object);
    }

    [InlineData("Ship 1")]
    [Theory]
    public async Task ClosestPort_Returns_ClosestPortDto(string name)
    {
        // Arrange
        var mockData = new Ship()
        {
            Id = Guid.NewGuid(),
            Name = "Ship 1",
            Position = new Position()
            {
                Latitude = 22,
                Longitude = 113,
            },
            Velocity = 100
        };

        var mockData2 = new Port()
        {
            Id = Guid.NewGuid(),
            Position = new Position
            {
                Longitude = 116,
                Latitude = 20
            },
            Name = "Victoria Harbour",
        };

        var shipRepo = new Repository<Ship>
        {
            Entities = new List<Ship> { mockData }
        };

        var portRepo = new Repository<Port>
        {
            Entities = new List<Port> { mockData2 }
        };

        _mockRepositoryFactory
            .Setup(x => x.GetRepository<Ship>())
            .Returns(shipRepo);

        _mockRepositoryFactory
            .Setup(x => x.GetRepository<Port>())
            .Returns(portRepo);

        // Act
        Func<Task> act = async () => { await _shipService.ClosestPort(name); };

        // Assert
        await act.Should().NotThrowAsync();
    }

    [InlineData("")]
    [Theory]
    public void ClosestPort_Returns_Null(string name)
    {
        // Arrange
        var mockData2 = new Port()
        {
            Id = Guid.NewGuid(),
            Position = new Position
            {
                Longitude = 116,
                Latitude = 20
            },
            Name = "Victoria Harbour",
        };

        var shipRepo = new Repository<Ship>
        {
            Entities = new List<Ship> {  }
        };

        var portRepo = new Repository<Port>
        {
            Entities = new List<Port> { mockData2 }
        };

        _mockRepositoryFactory
            .Setup(x => x.GetRepository<Ship>())
            .Returns(shipRepo);

        _mockRepositoryFactory
            .Setup(x => x.GetRepository<Port>())
            .Returns(portRepo);

        // Act
        var result = _shipService.ClosestPort(name);

        // Assert
        result.Should().BeNull();
    }

    [InlineData("")]
    [Theory]
    public void CreateShip_Returns_Ship_Result(string name)
    {
        // Arrange
        var mockRequest = new CreateShipRequest
        {
            Name = "Ship 1",
            Position = new Position()
            {
                Latitude = 22,
                Longitude = 113,
            }
        };

        var mockData = new Ship()
        {
            Id = Guid.NewGuid(),
            Name = "Ship 1",
            Position = new Position()
            {
                Latitude = 22,
                Longitude = 113,
            },
            Velocity = 100
        };

        var mockData2 = new Port()
        {
            Id = Guid.NewGuid(),
            Position = new Position
            {
                Longitude = 116,
                Latitude = 20
            },
            Name = "Victoria Harbour",
        };

        var shipRepo = new Repository<Ship>
        {
            Entities = new List<Ship> { }
        };

        var portRepo = new Repository<Port>
        {
            Entities = new List<Port> { mockData2 }
        };

        _mockMapper
            .Setup(x => x.Map<Ship>(mockRequest))
            .Returns(mockData);

        _mockRepositoryFactory
            .Setup(x => x.GetRepository<Ship>())
            .Returns(shipRepo);

        _mockRepositoryFactory
            .Setup(x => x.GetRepository<Port>())
            .Returns(portRepo);

        // Act
        var result = _shipService.CreateShip(mockRequest);

        // Assert
        result.Should().NotBeNull();
    }
}
