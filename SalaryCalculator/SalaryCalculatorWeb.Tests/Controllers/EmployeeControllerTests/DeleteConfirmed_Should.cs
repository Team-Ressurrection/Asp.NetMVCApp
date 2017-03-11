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
    public class DeleteConfirmed_Should
    {
        [Test]
        public void ReturnRedirectToRouteResult_WhenIdIsCorrect()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            EmployeesController emplController = new EmployeesController(employeeService.Object);
            var employeeId = 5;
            employeeService.Setup(x => x.DeleteById(employeeId)).Verifiable();
            // Act
            emplController.DeleteConfirmed(employeeId);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(emplController.DeleteConfirmed(employeeId));
        }
    }
}
