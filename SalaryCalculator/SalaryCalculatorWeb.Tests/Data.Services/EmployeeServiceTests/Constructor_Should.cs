using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Services;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class EmployeeServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Employee>>();

            // Act
            var emplService = new EmployeeService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf(typeof(EmployeeService), emplService);
        }
    }
}
