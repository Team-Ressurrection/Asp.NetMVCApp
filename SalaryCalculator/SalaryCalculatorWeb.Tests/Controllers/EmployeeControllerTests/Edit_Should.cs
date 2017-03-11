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
    public class Edit_Should
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
            emplController.Edit(employeeId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Edit(employeeId));
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
            emplController.Edit(employeeId);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(emplController.Edit(employeeId));
        }

        [Test]
        public void ReturnViewResult_WhenModelStateIsNotValid()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(employeeService.Object);
            Employee employee = null;
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
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(employeeService.Object);
            var employee = new Employee()
            {
                Id = 5,
                FirstName = "Alex",
                MiddleName = "Parvanov",
                LastName ="Petrov",
                PersonalId = "9010103040"
            };

            employeeService.Setup(x => x.UpdateById(5, employee)).Verifiable();
            // Act
            emplController.Edit(employee);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(emplController.Edit(employee));
        }
    }
}
