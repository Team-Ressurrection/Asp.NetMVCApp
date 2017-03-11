using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SalaryCalculatorWeb;
using SalaryCalculatorWeb.Controllers;
using NUnit.Framework;
using Moq;
using SalaryCalculator.Configuration.Caching;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Models.HomeViewModels;

namespace SalaryCalculatorWeb.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            HomeController controller = new HomeController(cacheService.Object, userService.Object);

            var infoViewModel = new Mock<InfoViewModel>();
            // Act
            ViewResult result = controller.Index(infoViewModel.Object) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            HomeController controller = new HomeController(cacheService.Object, userService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            HomeController controller = new HomeController(cacheService.Object, userService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
