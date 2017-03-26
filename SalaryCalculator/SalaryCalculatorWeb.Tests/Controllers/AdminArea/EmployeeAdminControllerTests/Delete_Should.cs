using AutoMapper;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.EmployeeAdminControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();
            EmployeeAdminController userController = new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory.Object, employeeService.Object);
            var id = 15;
            employeeService.Setup(x => x.GetById(id)).Returns(new Employee() { Id =id });

            // Act & Assert
            Assert.IsInstanceOf<ViewResult>(userController.Delete(id,new Employee() { Id = id}));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();
            EmployeeAdminController userController = new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory.Object, employeeService.Object);
            var id = 10;
            Employee employee = null;
            employeeService.Setup(x => x.GetById(id)).Returns(employee);
            
            // Act & Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(userController.Delete(id,employee));
        }

        [Test]
        public void ReturnRedirectToRouteResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();
            EmployeeAdminController userController = new EmployeeAdminController(mockedMapService.Object, mockedPagerFactory.Object, employeeService.Object);
            var id = 5;
            employeeService.Setup(x => x.DeleteById(id)).Verifiable();

            // Act & Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(userController.DeleteConfirmed(id, new EmployeesViewModel() { Id = id }));
        }
    }
}
