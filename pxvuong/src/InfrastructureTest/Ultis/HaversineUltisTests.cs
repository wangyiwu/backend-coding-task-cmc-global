using Infrastructure.Ultis;
using Moq;
using System;
using Xunit;

namespace InfrastructureTest.Ultis
{
    public class HaversineUltisTests
    {
        private MockRepository mockRepository;



        public HaversineUltisTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

        }


        [Fact]
        public void CalculateDistance_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
;
            double lat1 = 0;
            double lon1 = 0;
            double lat2 = 0;
            double lon2 = 0;

            // Act
            var result = DistanceUltis.CalculateDistance(
                lat1,
                lon1,
                lat2,
                lon2);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
