using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Services;

namespace SalaryCalculator.Tests.Data.Services.SelfEmploymentServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            // Act
            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf(typeof(SelfEmploymentService), selfEmplService);
        }
    }
}
