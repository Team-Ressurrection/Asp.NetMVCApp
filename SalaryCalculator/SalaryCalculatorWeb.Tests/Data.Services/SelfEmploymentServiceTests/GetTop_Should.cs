using System.Linq;

using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.SelfEmploymentServiceTests
{
    [TestFixture]
    public class GetTop_Should
    {
        [Test]
        public void ShouldInvokeOnlyOnce_WhenIsCalled()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            SelfEmployment mockedSelfEmpl = new FakeSelfEmployment();
            SelfEmployment mockedSelfEmpl2 = new FakeSelfEmployment();
            SelfEmployment mockedSelfEmpl3 = new FakeSelfEmployment();
            mockedSelfEmpl.Id = 2;
            mockedSelfEmpl2.Id = 3;
            mockedSelfEmpl3.Id = 4;

            // Act
            selfEmplService.Create(mockedSelfEmpl);
            selfEmplService.Create(mockedSelfEmpl2);
            selfEmplService.Create(mockedSelfEmpl3);

            selfEmplService.GetTop(3);

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void ShouldReturnInstanceOfIQueryable()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<SelfEmployment>>();

            var selfEmplService = new SelfEmploymentService(mockedRepository.Object);

            SelfEmployment mockedSelfEmpl = new  FakeSelfEmployment();
            SelfEmployment mockedSelfEmpl2 = new FakeSelfEmployment();
            SelfEmployment mockedSelfEmpl3 = new FakeSelfEmployment();
            mockedSelfEmpl.Id = 2;
            mockedSelfEmpl2.Id = 3;
            mockedSelfEmpl3.Id = 4;

            // Act
            selfEmplService.Create(mockedSelfEmpl);
            selfEmplService.Create(mockedSelfEmpl2);
            selfEmplService.Create(mockedSelfEmpl3);

            var query = selfEmplService.GetTop(3);

            // Assert
            Assert.IsInstanceOf<IQueryable<SelfEmployment>>(query);
        }
    }
}
