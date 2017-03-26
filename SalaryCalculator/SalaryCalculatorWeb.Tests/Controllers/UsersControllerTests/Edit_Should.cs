using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.UsersControllerTests
{
    [TestFixture]
   public class Edit_Should
    {
        [Test]
        public void HttpGet_ReturnUsersViewModel_WhenActionIsCalled()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = Guid.NewGuid();
            var userModel = new Mock<UsersViewModel>();
            userModel.Setup(x => x.Id).Returns(id.ToString()).Verifiable();
            User mockedUser = new FakeUser()
            {
                Id = id.ToString(),
                UserName = "Payroll",
                CompanyName = "Company",
                CompanyAddress = "Address",
            };

            userService.Setup(x => x.GetById(id.ToString())).Returns(mockedUser).Verifiable();
            mapService.Setup(x => x.Map<UsersViewModel>(mockedUser)).Returns(userModel.Object).Verifiable();
            // Act
            var usersController = new UsersController(mapService.Object, userService.Object, pagerFactory.Object);
            var result = usersController.Edit(id, userModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<UsersViewModel>(result.Model);
        }

        [Test]
        public void HttpGet_ReturnHttpNotFoundResult_WhenPaycheckIsNull()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = Guid.NewGuid();
            var userModel = new Mock<UsersViewModel>();
            userModel.Setup(x => x.Id).Returns(id.ToString()).Verifiable();
            User mockedUser = null;

            userService.Setup(x => x.GetById(id.ToString())).Returns(mockedUser).Verifiable();

            // Act & Assert
            var usersController = new UsersController(mapService.Object, userService.Object, pagerFactory.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(usersController.Edit(id, userModel.Object));
        }

        [Test]
        public void HttpPost_ReturnRedirectToRouteResult_WhenModelStateIsValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var id = Guid.NewGuid();
            var userModel = new Mock<UsersViewModel>();
            userModel.SetupProperty(x => x.Id, id.ToString());
            User mockedUser = new FakeUser()
            {
                Id = id.ToString(),
                UserName = "Payroll",
                CompanyName = "Company",
                CompanyAddress = "Address",
            };

            userService.Setup(x => x.GetById(id.ToString())).Returns(mockedUser).Verifiable();
            mapService.Setup(x => x.Map<User>(userModel.Object)).Returns(mockedUser).Verifiable();

            // Act
            var usersController = new UsersController(mapService.Object, userService.Object, pagerFactory.Object);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(usersController.Edit(userModel.Object));
        }

        [Test]
        public void HttpPost_ReturnUsersViewModel_WhenModelState_IsNotValid()
        {
            // Arrange
            var mapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            var pagerFactory = new Mock<IPagerFactory>();

            var userModel = new Mock<UsersViewModel>();

            // Act
            var usersController = new UsersController(mapService.Object, userService.Object, pagerFactory.Object);
            usersController.ModelState.AddModelError("Invalid", "Invalid");

            var result = usersController.Edit(userModel.Object) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(userModel.Object, result.Model);
        }
    }
}
