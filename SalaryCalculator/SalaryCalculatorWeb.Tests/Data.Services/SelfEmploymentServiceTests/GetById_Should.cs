using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.SelfEmploymentServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            var mockedSelfEmployment = new FakeSelfEmployment();
            mockedSelfEmployment.Id = 2;

            // Act
            selfEmplService.Create(mockedSelfEmployment);

            selfEmplService.GetById(mockedSelfEmployment.Id);

            // Assert
            mockedRepository.Verify(r => r.GetById(mockedSelfEmployment.Id), Times.Once);
        }
    }
}
