using System.Web.Mvc;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.PaycheckControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();
            PaychecksController paycheckController = new PaychecksController(mockedMapService.Object, mockedPagerFactory.Object, employeePaycheckService.Object);
            var id = 15;
            employeePaycheckService.Setup(x => x.GetById(id)).Returns(new EmployeePaycheck() { Id =id });


            // Act & Assert
            Assert.IsInstanceOf<ViewResult>(paycheckController.Delete(id,new EmployeePaycheck() { Id = id}));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();
            PaychecksController paycheckController = new PaychecksController(mockedMapService.Object, mockedPagerFactory.Object, employeePaycheckService.Object);
            var id = 10;
            EmployeePaycheck paycheck = null;
            employeePaycheckService.Setup(x => x.GetById(id)).Returns(paycheck);
            
            // Act & Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(paycheckController.Delete(id,paycheck));
        }

        [Test]
        public void ReturnRedirectToRouteResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();
            PaychecksController paycheckController = new PaychecksController(mockedMapService.Object, mockedPagerFactory.Object, employeePaycheckService.Object);
            var id = 5;
            employeePaycheckService.Setup(x => x.DeleteById(id)).Verifiable();

            // Act & Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(paycheckController.DeleteConfirmed(id, new PaycheckViewModel() { Id = id }));
        }
    }
}
