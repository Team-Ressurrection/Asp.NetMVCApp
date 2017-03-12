using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorWeb.Tests.Controllers.EmployeeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersAreSetUpCorrectly()
        {
            // Arrange
            var mockedMappService = new Mock<IMapService>();
            var employeeService = new Mock<IEmployeeService>();

            // Act
            EmployeesController emplController = new EmployeesController(mockedMappService.Object, employeeService.Object);

            // Assert
            Assert.IsInstanceOf<EmployeesController>(emplController);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIMapperIsNull()
        {
            // Arrange
            IMapService mockedMapService = null;
            var mockedEmployeeService = new Mock<IEmployeeService>();

            // Act & Assert
            Assert.That(() => new EmployeesController(mockedMapService, mockedEmployeeService.Object), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmployeeServiceIsNull()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            IEmployeeService nullableEmployeeService = null;

            // Act & Assert
            Assert.That(() => new EmployeesController(mockedMapService.Object, nullableEmployeeService), Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }
    }
}
