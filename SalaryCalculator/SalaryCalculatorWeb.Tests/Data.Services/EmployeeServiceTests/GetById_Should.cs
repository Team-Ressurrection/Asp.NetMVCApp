using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.EmployeeServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Employee>>();

            var emplService = new EmployeeService(mockedRepository.Object);

            var employee = new FakeEmployee();
            employee.Id = 2;

            // Act
            emplService.Create(employee);

            emplService.GetById(employee.Id);

            // Assert
            mockedRepository.Verify(r => r.GetById(employee.Id), Times.Once);
        }
    }
}
