using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Calculations;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.ContractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.LaborContractControllerTests
{
    [TestFixture]
    public class CreateLaborContract_Should
    {
        [Test]
        public void ReturnPreviewLaborContractViewModel_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();
            laborContractModel.SetupProperty(x => x.GrossSalary, 1000);
            laborContractModel.SetupProperty(x => x.GrossFixedBonus, 100);
            laborContractModel.SetupProperty(x => x.GrossNonFixedBonus, 100);

            Employee mockedEmployee = new FakeEmployee()
            {
                Id = id,
                FirstName = "Alexander",
                MiddleName = "Petrov",
                LastName = "Vasilev",
                PersonalId = "8010107070"
            };
            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();
            
            // Act
            LaborContractController laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);

            var result = laborController.CreateLaborContract(id, laborContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.AreEqual(laborContractModel.Object, result.Model);
        }

        [Test]
        public void ReturnCreateLaborContractViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var laborContractModel = new Mock<PreviewEmployeePaycheckViewModel>();
            laborContractModel.SetupProperty(x => x.GrossSalary, 1000);
            laborContractModel.SetupProperty(x => x.GrossFixedBonus, 100);
            laborContractModel.SetupProperty(x => x.GrossNonFixedBonus, 100);

            Employee mockedEmployee = new FakeEmployee()
            {
                Id = id,
                FirstName = "Alexander",
                MiddleName = "Petrov",
                LastName = "Vasilev",
                PersonalId = "8010107070"
            };
            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();
            
            // Act
            LaborContractController laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("invalid", "Invalid");

            var result = laborController.CreateLaborContract(id, laborContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(laborContractModel.Object, result.Model);
        }

        [Test]
        public void ReturnCreateEmployeePaycheckViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;

            Employee mockedEmployee = new FakeEmployee()
            {
                Id = id,
                FirstName = "Alexander",
                MiddleName = "Petrov",
                LastName = "Vasilev",
                PersonalId = "8010107070"
            };

            EmployeePaycheck mockedPaycheck = new FakeEmployeePaycheck()
            {
                Id = 1,
                EmployeeId = id,
                Employee = mockedEmployee
            };

            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();

            var laborContractModel = new CreateEmployeePaycheckViewModel();
            mapService.Setup(x => x.Map<CreateEmployeePaycheckViewModel>(mockedPaycheck)).Returns(laborContractModel).Verifiable();
            
            // Act
            LaborContractController laborController = new LaborContractController(mapService.Object, employeeService.Object, paycheckService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("invalid", "Invalid");

            var result = laborController.CreateLaborContract(id, mockedPaycheck) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(laborContractModel, result.Model);
        }
    }
}
