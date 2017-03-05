using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Data.Services.Contracts;

namespace SalaryCalculator.Tests.Data.Services.EmployeePaycheckServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParameterIRepositoryIsPassedCorrectly()
        {
            // Arrange
            var repo = new Mock<IRepository<EmployeePaycheck>>();

            // Act
            var paycheckService = new EmployeePaycheckService(repo.Object);

            // Assert
            Assert.IsInstanceOf<IEmployeePaycheckService>(paycheckService);
        }
    }
}
