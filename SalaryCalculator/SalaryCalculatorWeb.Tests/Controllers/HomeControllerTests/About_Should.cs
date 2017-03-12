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

namespace SalaryCalculatorWeb.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class About_Should
    {
        [Test]
        public void ReturnViewResult()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            HomeController controller = new HomeController(cacheService.Object, userService.Object, paycheckService.Object, billService.Object, selfEmploymentService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
