using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Update_ShouldUpdateEmployeeCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<EmployeePaycheck>>();

            var emplPaycheckService = new EmployeePaycheckService(mockedRepository.Object);

            EmployeePaycheck paycheck = new FakeEmployeePaycheck();
            paycheck.Id = 2;

            // Act
            emplPaycheckService.Create(paycheck);

            emplPaycheckService.UpdateById(2, paycheck);

            // Assert
            mockedRepository.Verify(x => x.Update(paycheck), Times.Once);
        }
    }
}
