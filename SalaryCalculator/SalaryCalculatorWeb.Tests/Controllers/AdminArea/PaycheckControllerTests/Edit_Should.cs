using System.Web.Mvc;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.PaycheckControllerTests
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void HttpGet_ReturnEmployeesViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mapService = new Mock<IMapService>();

            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = 10;
            var paycheckModel = new Mock<PaycheckViewModel>();
            paycheckModel.Setup(x => x.Id).Returns(id).Verifiable();
            EmployeePaycheck mockedPaycheck = new FakeEmployeePaycheck()
            {
                Id = id,
            };

            employeePaycheckService.Setup(x => x.GetById(id)).Returns(mockedPaycheck).Verifiable();
            mapService.Setup(x => x.Map<PaycheckViewModel>(mockedPaycheck)).Returns(paycheckModel.Object).Verifiable();
            // Act
            PaychecksController paycheckController = new PaychecksController(mapService.Object, pagerFactory.Object, employeePaycheckService.Object);
            var result = paycheckController.Edit(id, paycheckModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<PaycheckViewModel>(result.Model);
        }

        [Test]
        public void HttpGet_ReturnHttpNotFoundResult_WhenPaycheckIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = 15;
            var mockedPaycheck = new Mock<PaycheckViewModel>();
            mockedPaycheck.Setup(x => x.Id).Returns(id).Verifiable();
            EmployeePaycheck mockedEmployee = null;

            employeePaycheckService.Setup(x => x.GetById(id)).Returns(mockedEmployee).Verifiable();

            // Act & Assert
            PaychecksController paycheckController = new PaychecksController(mapService.Object, pagerFactory.Object, employeePaycheckService.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(paycheckController.Edit(id, mockedPaycheck.Object));
        }

        [Test]
        public void HttpPost_ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = 20;
            var paycheckModel = new Mock<PaycheckViewModel>();
            paycheckModel.SetupProperty(x => x.Id, id);
            EmployeePaycheck mockedPaycheck = new FakeEmployeePaycheck()
            {
                Id = id,
            };

            employeePaycheckService.Setup(x => x.GetById(id)).Returns(mockedPaycheck).Verifiable();
            mapService.Setup(x => x.Map<EmployeePaycheck>(paycheckModel.Object)).Returns(mockedPaycheck).Verifiable();

            // Act
            PaychecksController paycheckController = new PaychecksController(mapService.Object, pagerFactory.Object, employeePaycheckService.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(paycheckController.Edit(paycheckModel.Object));
        }

        [Test]
        public void HttpPost_ReturnEmployeesViewModel_WhenModelState_IsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var employeePaycheckService = new Mock<IEmployeePaycheckService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var paycheckModel = new Mock<PaycheckViewModel>();

            // Act
            PaychecksController paycheckController = new PaychecksController(mapService.Object, pagerFactory.Object, employeePaycheckService.Object);
            paycheckController.ModelState.AddModelError("Invalid", "Invalid");

            var result = paycheckController.Edit(paycheckModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(paycheckModel.Object, result.Model);
        }
    }
}
