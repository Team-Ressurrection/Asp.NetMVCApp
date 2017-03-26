using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.EmployeeAdminControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedEmployeeService = new Mock<IEmployeeService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act
            EmployeeAdminController employeeAdminController = new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory.Object, mockedEmployeeService.Object);

            // Assert
            Assert.IsInstanceOf<EmployeeAdminController>(employeeAdminController);
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterMapServiceIsNullable()
        {
            // Arrange
            IMapService mockedMapService = null;
            var mockedUserService = new Mock<IEmployeeService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeeAdminController(mockedMapService, mockedPagerFactory.Object, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterUserServiceIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            IEmployeeService mockedUserService = null;
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory.Object, mockedUserService));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterPagerFactoryIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedUserService = new Mock<IEmployeeService>();
            IPagerFactory mockedPagerFactory = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory, mockedUserService.Object));
        }
    }
}
