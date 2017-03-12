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
    public class Details_Should
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
            emplController.Details(employeeId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Details(employeeId));
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
            emplController.Details(employeeId);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(emplController.Details(employeeId));
        }
    }
}
