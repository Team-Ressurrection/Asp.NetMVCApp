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

namespace SalaryCalculatorWeb.Tests.Controllers.NonLaborContractControllerTests
{
    [TestFixture]
    public class CreateLaborContract_Should
    {
        [Test]
        public void ReturnPreviewRemunerationBillViewModel_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();
            nonLaborContractModel.SetupProperty(x => x.GrossSalary, 1000);

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
            NonLaborContractController laborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);

            var result = laborController.CreateNonLaborContract(id, nonLaborContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.AreEqual(nonLaborContractModel.Object, result.Model);
        }

        [Test]
        public void ReturnCreateLaborContractViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var nonLaborContractModel = new Mock<PreviewRemunerationBillViewModel>();
            nonLaborContractModel.SetupProperty(x => x.GrossSalary, 1000);

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
            NonLaborContractController laborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("invalid", "Invalid");

            var result = laborController.CreateNonLaborContract(id, nonLaborContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(nonLaborContractModel.Object, result.Model);
        }

        [Test]
        public void ReturnCreateRemunerationBillViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var billService = new Mock<IRemunerationBillService>();
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

            RemunerationBill mockedBill = new FakeRemunerationBill()
            {
                Id = 1,
                EmployeeId = id,
                Employee = mockedEmployee
            };

            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();

            var nonLaborContractModel = new CreateRemunerationBillViewModel();
            mapService.Setup(x => x.Map<CreateRemunerationBillViewModel>(mockedBill)).Returns(nonLaborContractModel).Verifiable();
            
            // Act
            NonLaborContractController laborController = new NonLaborContractController(mapService.Object, employeeService.Object, billService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("invalid", "Invalid");

            var result = laborController.CreateNonLaborContract(id, mockedBill) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(nonLaborContractModel, result.Model);
        }
    }
}
