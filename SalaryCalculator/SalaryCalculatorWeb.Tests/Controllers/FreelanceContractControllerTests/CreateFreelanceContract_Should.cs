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

namespace SalaryCalculatorWeb.Tests.Controllers.FreelanceContractControllerTests
{
    [TestFixture]
    public class CreateFreelanceContract_Should
    {
        [Test]
        public void ReturnPreviewSelfEmploymentViewModel_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();
            freelanceContractModel.SetupProperty(x => x.GrossSalary, 1000);

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
            FreelanceContractController laborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);

            var result = laborController.CreateFreelanceContract(id, freelanceContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.AreEqual(freelanceContractModel.Object, result.Model);
        }

        [Test]
        public void ReturnCreateLaborContractViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            var payrollCalculations = new Mock<Payroll>();

            var id = 5;
            var freelanceContractModel = new Mock<PreviewSelfEmploymentViewModel>();
            freelanceContractModel.SetupProperty(x => x.GrossSalary, 1000);

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
            FreelanceContractController laborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("invalid", "Invalid");

            var result = laborController.CreateFreelanceContract(id, freelanceContractModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(freelanceContractModel.Object, result.Model);
        }

        [Test]
        public void ReturnCreateRemunerationBillViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
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

            SelfEmployment mockedSelfEmpl = new FakeSelfEmployment()
            {
                Id = 1,
                EmployeeId = id,
                Employee = mockedEmployee
            };

            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();

            var freelanceContractModel = new CreateSelfEmploymentViewModel();
            mapService.Setup(x => x.Map<CreateSelfEmploymentViewModel>(mockedSelfEmpl)).Returns(freelanceContractModel).Verifiable();
            
            // Act
            FreelanceContractController laborController = new FreelanceContractController(mapService.Object, employeeService.Object, selfEmploymentService.Object, payrollCalculations.Object);
            laborController.ModelState.AddModelError("invalid", "Invalid");

            var result = laborController.CreateFreelanceContract(id, mockedSelfEmpl) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(freelanceContractModel, result.Model);
        }
    }
}
