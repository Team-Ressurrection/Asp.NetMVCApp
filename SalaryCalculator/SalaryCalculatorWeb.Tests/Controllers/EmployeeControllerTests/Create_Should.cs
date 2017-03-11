using Moq;
using NUnit.Framework;
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
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(employeeService.Object);
            
            // Act
            emplController.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(emplController.Create());
        }
    }
}
