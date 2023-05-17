using Domain.Entities;
using Domain.Repository;
using Xunit;

namespace InfrastructureTest
{
    public class RepositoryFactoryTest
    {
        [Fact]
        public void GetRepository_ShouldReturnDifferentInstances_ForDifferentEntityTypes()
        {
            // Arrange
            var repositoryFactory = new RepositoryFactory();

            // Act
            var repository1 = repositoryFactory.GetRepository<Ship>();
            var repository2 = repositoryFactory.GetRepository<Port>();

            // Assert
            Assert.NotSame(repository1, repository2);
        }

    }
}
