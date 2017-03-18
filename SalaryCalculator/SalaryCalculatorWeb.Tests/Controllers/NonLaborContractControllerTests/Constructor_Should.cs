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

namespace SalaryCalculatorWeb.Tests.Controllers.NonLaborContractControllerTests
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
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();
            
            // Act & Assert
            Assert.IsInstanceOf<NonLaborContractController>(new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenMapServiceIsNull()
        {
            // Arrange
            IMapService mapService = null;
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new NonLaborContractController(mapService, employeeService.Object, billService.Object, payrollCalculations.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmployeeServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            IEmployeeService employeeService = null;
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new NonLaborContractController(mapService.Object, employeeService, billService.Object, payrollCalculations.Object));

        }

        [Test]
        public void ThrowArgumentNullException_WhenBillServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            IRemunerationBillService billService = null;
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new NonLaborContractController(mapService.Object, employeeService.Object, billService, payrollCalculations.Object));

        }

        [Test]
        public void ThrowArgumentNullException_WhenPayrollIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            Payroll payrollCalculations = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations));
        }
    }
}
