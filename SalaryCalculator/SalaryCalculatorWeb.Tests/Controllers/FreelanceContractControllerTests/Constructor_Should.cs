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

namespace SalaryCalculatorWeb.Tests.Controllers.FreelanceContractControllerTests
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
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();
            
            // Act & Assert
            Assert.IsInstanceOf<FreelanceContractController>(new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenMapServiceIsNull()
        {
            // Arrange
            IMapService mapService = null;
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FreelanceContractController(mapService, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmployeeServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            IEmployeeService employeeService = null;
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FreelanceContractController(mapService.Object, employeeService, selfEmploymentService.Object, payrollCalculations.Object));

        }

        [Test]
        public void ThrowArgumentNullException_WhenselfEmploymentServiceIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            ISelfEmploymentService selfEmploymentService = null;
            var payrollCalculations = new Mock<Payroll>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService, payrollCalculations.Object));

        }

        [Test]
        public void ThrowArgumentNullException_WhenPayrollIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            Payroll payrollCalculations = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations));
        }
    }
}