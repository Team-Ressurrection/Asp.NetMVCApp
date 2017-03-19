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
    public class Edit_Should
    {
        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object, employeeService.Object);
            var employeeId = 5;
            employeeService.Setup(x => x.GetById(employeeId)).Returns(new Employee() { Id = employeeId });
            // Act
            emplController.Edit(employeeId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Edit(employeeId));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object, employeeService.Object);
            var employeeId = 5;
            Employee employee = null;
            employeeService.Setup(x => x.GetById(employeeId)).Returns(employee);
            
            // Act
            emplController.Edit(employeeId);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(emplController.Edit(employeeId));
        }

        [Test]
        public void ReturnViewResult_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object, employeeService.Object);
            EmployeeViewModel employee = null;
            emplController.ModelState.AddModelError("invalid", "invalid");
            // Act
            emplController.Edit(employee);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Edit(employee));
        }

        [Test]
        public void ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(mockedMappService.Object, employeeService.Object);
            var employee = new EmployeeViewModel()
            {
                Id = 5,
                FirstName = "Alex",
                MiddleName = "Parvanov",
                LastName ="Petrov",
                PersonalId = "9010103040"
            };

            var employeeViewModel = new Employee()
            {
                Id = 5,
                FirstName = "Alex",
                MiddleName = "Parvanov",
                LastName = "Petrov",
                PersonalId = "9010103040"
            };
            employeeService.Setup(x => x.UpdateById(5, employeeViewModel)).Verifiable();
            mockedMappService.Setup(x => x.Map<Employee>(employee)).Returns(employeeViewModel);
            // Act
            emplController.Edit(employee);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(emplController.Edit(employee));
        }
    }
}
