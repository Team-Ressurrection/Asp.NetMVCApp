using System.Web.Mvc;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.ContractViewModels;

namespace SalaryCalculatorWeb.Tests.Controllers.LaborContractControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnRedirectToRouteResult_WhenPassedIdIsCorrect()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();

            // Act
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);

            var result = laborController.DeleteConfirmed(id, laborContractModel.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            EmployeePaycheck laborContractModel = new FakeEmployeePaycheck()
            {
                Id = id,
                GrossSalary = 1000,
                GrossFixedBonus = 100,
                GrossNonFixedBonus = 10,
                SocialSecurityIncome = 1110,
                PersonalInsurance = 50,
            };
            paycheckService.Setup(x => x.GetById(id)).Returns(laborContractModel).Verifiable();

            // Act
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<ViewResult>(laborController.Delete(id,laborContractModel));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            EmployeePaycheck laborContractModel = null;

            paycheckService.Setup(x => x.GetById(id)).Returns(laborContractModel).Verifiable();
            
            // Act
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(laborController.Delete(id,laborContractModel));
        }
    }
}
