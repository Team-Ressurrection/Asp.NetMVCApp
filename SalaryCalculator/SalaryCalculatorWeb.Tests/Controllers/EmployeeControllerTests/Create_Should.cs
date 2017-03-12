using AutoMapper;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Controllers;
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
            Employee employee = null;
            emplController.ModelState.AddModelError("invalid", "invalid");
            // Act
            emplController.Create(employee);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Create(employee));
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

            employeeService.Setup(x => x.Create(employee)).Verifiable();
            // Act
            emplController.Create(employee);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(emplController.Create(employee));
        }
    }
}
