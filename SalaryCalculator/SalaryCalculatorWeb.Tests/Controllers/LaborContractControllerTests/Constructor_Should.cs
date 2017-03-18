using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorWeb.Tests.Controllers.LaborContractControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllServicesArePassedCorrectly()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();
            
            // Act & Assert
            Assert.IsInstanceOf<LaborContractController>(new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCacheServiceIsNull()
        {
            // Arrange
            IMapService mapService = null;
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LaborContractController(mapService, employeeService.Object, paycheckService.Object, payrollCalculations.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPaycheckServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            IEmployeeService employeeService = null;
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LaborContractController(mapService.Object, employeeService, paycheckService.Object, payrollCalculations.Object));

        }

        [Test]
        public void ThrowArgumentNullException_WhenBillServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            IEmployeePaycheckService paycheckService = null;
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LaborContractController(mapService.Object, employeeService.Object, paycheckService, payrollCalculations.Object));

        }

        [Test]
        public void ThrowArgumentNullException_WhenSelfEmploymentServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            Payroll payrollCalculations = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations));
        }
    }
}
