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

namespace SalaryCalculatorWeb.Tests.Controllers.NonLaborContractControllerTests
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void HttpGet_ReturnPreviewRemunerationBillViewModel_WhenPaycheckIsNotNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();

            var employeeId = 10;
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = employeeId,
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                PersonalId = "8010104050"
            };

            RemunerationBill mockedBill = new FakeRemunerationBill()
            {
                Id = id,
                GrossSalary = 1000,
                SocialSecurityIncome = 670,
                PersonalInsurance = 125,
                IncomeTax = 90,
                NetWage = 750,
                Employee = mockedEmployee,
                EmployeeId = mockedEmployee.Id
            };

            employeeService.Setup(x => x.GetById(10)).Returns(mockedEmployee).Verifiable();
            billService.Setup(x => x.GetById(id)).Returns(mockedBill).Verifiable();
            mapService.Setup(x => x.Map<PreviewRemunerationBillViewModel>(mockedBill)).Returns(new PreviewRemunerationBillViewModel() { Id = id, EmployeeId = employeeId }).Verifiable();
            // Act
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);
            var result = nonLaborController.Edit(id, mockedBill) as ViewResult;

            // Assert
            Assert.IsInstanceOf<PreviewRemunerationBillViewModel>(result.Model);
        }

        [Test]
        public void HttpGet_ReturnHttpNotFoundResult_WhenPaycheckIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();

            RemunerationBill mockedBill = null;

            billService.Setup(x => x.GetById(id)).Returns(mockedBill).Verifiable();
            
            // Act & Assert
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(nonLaborController.Edit(id, mockedBill));
        }

        [Test]
        public void HttpPost_ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();

            var employeeId = 10;
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = employeeId,
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                PersonalId = "8010104050"
            };

            var mockedBill = new FakeRemunerationBill()
            {
                Id = id,
                GrossSalary = 1000,
                SocialSecurityIncome = 670,
                PersonalInsurance = 125,
                IncomeTax = 90,
                NetWage = 750,
                Employee = mockedEmployee,
                EmployeeId = mockedEmployee.Id
            };

            employeeService.Setup(x => x.GetById(10)).Returns(mockedEmployee).Verifiable();
            billService.Setup(x => x.GetById(id)).Returns(mockedBill).Verifiable();
            mapService.Setup(x => x.Map<RemunerationBill>(nonLaborContractModel.Object)).Returns(mockedBill).Verifiable();

            // Act
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(nonLaborController.Edit(nonLaborContractModel.Object));
        }

        [Test]
        public void HttpPost_ReturnPreviewRemunerationBillViewModel_WhenModelState_IsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();

            // Act
            var nonLaborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);
            nonLaborController.ModelState.AddModelError("Invalid", "Invalid");

            var result = nonLaborController.Edit(nonLaborContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(nonLaborContractModel.Object, result.Model);
        }
    }
}
