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
    public class Edit_Should
    {
        [Test]
        public void HttpGet_ReturnPreviewEmployeePaycheckViewModel_WhenPaycheckIsNotNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();

            var employeeId = 10;
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = employeeId,
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                PersonalId = "8010104050"
            };

            EmployeePaycheck mockedPaycheck = new FakeEmployeePaycheck()
            {
                Id = id,
                GrossSalary = 1000,
                GrossFixedBonus = 100,
                GrossNonFixedBonus = 20,
                SocialSecurityIncome = 670,
                PersonalInsurance = 125,
                IncomeTax = 90,
                NetWage = 750,
                Employee = mockedEmployee,
                EmployeeId = mockedEmployee.Id
            };

            employeeService.Setup(x => x.GetById(10)).Returns(mockedEmployee).Verifiable();
            paycheckService.Setup(x => x.GetById(id)).Returns(mockedPaycheck).Verifiable();
            mapService.Setup(x => x.Map<PreviewEmployeePaycheckViewModel>(mockedPaycheck)).Returns(new PreviewEmployeePaycheckViewModel() { Id = id, EmployeeId = employeeId }).Verifiable();
            // Act
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);
            var result = laborController.Edit(id, mockedPaycheck) as ViewResult;

            // Assert
            Assert.IsInstanceOf<PreviewEmployeePaycheckViewModel>(result.Model);
        }

        [Test]
        public void HttpGet_ReturnHttpNotFoundResult_WhenPaycheckIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();

            EmployeePaycheck mockedPaycheck = null;

            paycheckService.Setup(x => x.GetById(id)).Returns(mockedPaycheck).Verifiable();
            
            // Act & Assert
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(laborController.Edit(id, mockedPaycheck));
        }

        [Test]
        public void HttpPost_ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();

            var employeeId = 10;
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = employeeId,
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                PersonalId = "8010104050"
            };

            var mockedPaycheck = new FakeEmployeePaycheck()
            {
                Id = id,
                GrossSalary = 1000,
                GrossFixedBonus = 100,
                GrossNonFixedBonus = 20,
                SocialSecurityIncome = 670,
                PersonalInsurance = 125,
                IncomeTax = 90,
                NetWage = 750,
                Employee = mockedEmployee,
                EmployeeId = mockedEmployee.Id
            };

            employeeService.Setup(x => x.GetById(10)).Returns(mockedEmployee).Verifiable();
            paycheckService.Setup(x => x.GetById(id)).Returns(mockedPaycheck).Verifiable();
            mapService.Setup(x => x.Map<EmployeePaycheck>(laborContractModel.Object)).Returns(mockedPaycheck).Verifiable();

            // Act
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(laborController.Edit(laborContractModel.Object));
        }

        [Test]
        public void HttpPost_ReturnPreviewEmployeePaycheckViewModel_WhenModelState_IsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();

            // Act
            var laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("Invalid", "Invalid");

            var result = laborController.Edit(laborContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(laborContractModel.Object, result.Model);
        }
    }
}
