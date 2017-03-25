using AutoMapper;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using SalaryCalculatorWeb.Areas.Admin.Models;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.UsersControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            UsersController userController = new UsersController(mockedMapService.Object, userService.Object);
            var id = Guid.NewGuid();
            userService.Setup(x => x.GetById(id.ToString())).Returns(new User() { Id =id.ToString() });

            // Act & Assert
            Assert.IsInstanceOf<ViewResult>(userController.Delete(id,new User() { Id = id.ToString()}));
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            UsersController userController = new UsersController(mockedMapService.Object, userService.Object);
            var id = Guid.NewGuid();
            User user = null;
            userService.Setup(x => x.GetById(id.ToString())).Returns(user);
            
            // Act & Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(userController.Delete(id,user));
        }

        [Test]
        public void ReturnRedirectToRouteResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var userService = new Mock<IUserService>();
            UsersController userController = new UsersController(mockedMapService.Object, userService.Object);
            var id = Guid.NewGuid();
            userService.Setup(x => x.DeleteById(id.ToString())).Verifiable();

            // Act & Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(userController.DeleteConfirmed(id, new UsersViewModel() { Id = id.ToString() }));
        }
    }
}
