using AutoMapper;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.EmployeeControllerTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnViewResult()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object,employeeService.Object);
            
            // Act
            emplController.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Create());
        }

        [Test]
        public void ReturnViewResult_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object,employeeService.Object);
            EmployeeViewModel employeeViewModel = null;
            emplController.ModelState.AddModelError("invalid", "invalid");
            // Act
            emplController.Create(employeeViewModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Create(employeeViewModel));
        }

        [Test]
        public void ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object,employeeService.Object);
            var employee = new Employee()
            {
                Id = 5,
                FirstName = "Elena",
                MiddleName = "Ivanova",
                LastName = "Petrova",
                PersonalId = "9010103040"
            };

            var employeeViewModel = new EmployeeViewModel();
            employeeService.Setup(x => x.Create(employee)).Verifiable();
            mockedMappService.Setup(x => x.Map<EmployeeViewModel>(employee)).Returns(employeeViewModel);
            // Act
            emplController.Create(employeeViewModel);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(emplController.Create(employeeViewModel));
        }
    }
}
