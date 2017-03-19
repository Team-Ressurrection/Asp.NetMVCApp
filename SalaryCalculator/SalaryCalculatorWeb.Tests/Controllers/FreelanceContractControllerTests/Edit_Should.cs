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

namespace SalaryCalculatorWeb.Tests.Controllers.FreelanceContractControllerTests
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void HttpGet_ReturnPreviewSelfEmploymentViewModel_WhenPaycheckIsNotNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();

            var employeeId = 10;
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = employeeId,
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                PersonalId = "8010104050"
            };

            SelfEmployment mockedBill = new FakeSelfEmployment()
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
            selfEmploymentService.Setup(x => x.GetById(id)).Returns(mockedBill).Verifiable();
            mapService.Setup(x => x.Map<PreviewSelfEmploymentViewModel>(mockedBill)).Returns(new PreviewSelfEmploymentViewModel() { Id = id, EmployeeId = employeeId }).Verifiable();
            // Act
            var nonLaborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);
            var result = nonLaborController.Edit(id, mockedBill) as ViewResult;

            // Assert
            Assert.IsInstanceOf<PreviewSelfEmploymentViewModel>(result.Model);
        }

        [Test]
        public void HttpGet_ReturnHttpNotFoundResult_WhenPaycheckIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();

            SelfEmployment mockedBill = null;

            selfEmploymentService.Setup(x => x.GetById(id)).Returns(mockedBill).Verifiable();
            
            // Act & Assert
            var nonLaborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(nonLaborController.Edit(id, mockedBill));
        }

        [Test]
        public void HttpPost_ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();

            var employeeId = 10;
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = employeeId,
                FirstName = "Georgi",
                MiddleName = "Georgiev",
                LastName = "Georgiev",
                PersonalId = "8010104050"
            };

            var mockedBill = new FakeSelfEmployment()
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
            selfEmploymentService.Setup(x => x.GetById(id)).Returns(mockedBill).Verifiable();
            mapService.Setup(x => x.Map<SelfEmployment>(freelanceContractModel.Object)).Returns(mockedBill).Verifiable();

            // Act
            var nonLaborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(nonLaborController.Edit(freelanceContractModel.Object));
        }

        [Test]
        public void HttpPost_ReturnPreviewSelfEmploymentViewModel_WhenModelState_IsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();

            // Act
            var nonLaborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);
            nonLaborController.ModelState.AddModelError("Invalid", "Invalid");

            var result = nonLaborController.Edit(freelanceContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(freelanceContractModel.Object, result.Model);
        }
    }
}
