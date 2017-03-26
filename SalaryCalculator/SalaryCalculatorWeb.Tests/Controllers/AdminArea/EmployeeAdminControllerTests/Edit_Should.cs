using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.EmployeeAdminControllerTests
{
    [TestFixture]
   public class Edit_Should
    {
        [Test]
        public void HttpGet_ReturnEmployeesViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = 10;
            var employeeModel = new Mock<EmployeesViewModel>();
            employeeModel.Setup(x => x.Id).Returns(id).Verifiable();
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = id,
                FirstName = "Georgi",
                MiddleName = "Petrov",
                LastName = "Nikolov",
            };

            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();
            mapService.Setup(x => x.Map<EmployeesViewModel>(mockedEmployee)).Returns(employeeModel.Object).Verifiable();
            // Act
            EmployeeAdminController employeeController = new EmployeeAdminController(mapService.Object, pagerFactory.Object, employeeService.Object);
            var result = employeeController.Edit(id, employeeModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<EmployeesViewModel>(result.Model);
        }

        [Test]
        public void HttpGet_ReturnHttpNotFoundResult_WhenPaycheckIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = 15;
            var employeeModel = new Mock<EmployeesViewModel>();
            employeeModel.Setup(x => x.Id).Returns(id).Verifiable();
            Employee mockedEmployee = null;

            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();

            // Act & Assert
            EmployeeAdminController employeeController = new EmployeeAdminController(mapService.Object, pagerFactory.Object, employeeService.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(employeeController.Edit(id, employeeModel.Object));
        }

        [Test]
        public void HttpPost_ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = 20;
            var employeeModel = new Mock<EmployeesViewModel>();
            employeeModel.SetupProperty(x => x.Id, id);
            Employee mockedEmployee = new FakeEmployee()
            {
                Id = id,
                FirstName = "Georgi",
                MiddleName = "Petrov",
                LastName = "Nikolov",
            };

            employeeService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();
            mapService.Setup(x => x.Map<Employee>(employeeModel.Object)).Returns(mockedEmployee).Verifiable();

            // Act
            EmployeeAdminController EmployeeController = new EmployeeAdminController(mapService.Object, pagerFactory.Object, employeeService.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(EmployeeController.Edit(employeeModel.Object));
        }

        [Test]
        public void HttpPost_ReturnEmployeesViewModel_WhenModelState_IsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var EmployeeModel = new Mock<EmployeesViewModel>();

            // Act
            EmployeeAdminController EmployeeController = new EmployeeAdminController(mapService.Object, pagerFactory.Object, employeeService.Object);
            EmployeeController.ModelState.AddModelError("Invalid", "Invalid");

            var result = EmployeeController.Edit(EmployeeModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(EmployeeModel.Object, result.Model);
        }
    }
}
