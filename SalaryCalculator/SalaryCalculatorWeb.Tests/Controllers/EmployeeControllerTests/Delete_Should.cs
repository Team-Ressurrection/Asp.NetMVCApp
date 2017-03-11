using Moq;
using NUnit.Framework;
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
    public class Delete_Should
    {
        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(employeeService.Object);
            var employeeId = 5;
            employeeService.Setup(x => x.GetById(employeeId)).Returns(new Employee() { Id = employeeId });
            // Act
            emplController.Delete(employeeId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Delete(employeeId));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(employeeService.Object);
            var employeeId = 5;
            Employee employee = null;
            employeeService.Setup(x => x.GetById(employeeId)).Returns(employee);
            
            // Act
            emplController.Delete(employeeId);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(emplController.Delete(employeeId));
        }
    }
}
