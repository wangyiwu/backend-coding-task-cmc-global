using Domain.Entities;
using Domain.Repository;
using Microsoft.VisualStudio.CodeCoverage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InfrastructureTest
{
    public class RepositoryFactoryTest
    {
        [Fact]
        public void GetRepository_ShouldReturnSameInstance_ForSameEntityType()
        {
            // Arrange
            var repositoryFactory = new RepositoryFactory();

            // Act
            var repository1 = repositoryFactory.GetRepository<Ship>();
            var repository2 = repositoryFactory.GetRepository<Shim>();

            // Assert
            Assert.Same(repository1, repository2);
        }

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
}
