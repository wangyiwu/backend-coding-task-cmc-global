using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Xunit;

namespace DomainTest;

public class PortSeedDataTest
{
    public PortSeedDataTest()
    {
        
    }

    [Fact]
    public void PortSeedData_Returns_Ok()
    {
        // Arrange

        // Act
        var result = PortSeedData.SeedPortData();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<Port>>();
    }
}
