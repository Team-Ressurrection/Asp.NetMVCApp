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
    public class Information_Should
    {
        [Test]
        public void ReturnPartialViewResult()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();
            HomeController controller = new HomeController(cacheService.Object, userService.Object, paycheckService.Object, billService.Object,selfEmploymentService.Object);

            cacheService.Setup(x => x.Get("t1", () => userService.Object.GetAll().Count(), 60)).Returns(2);
            cacheService.Setup(x => x.Get("t1", () => paycheckService.Object.GetAll().Count(), 60)).Returns(2);
            cacheService.Setup(x => x.Get("t1", () => billService.Object.GetAll().Count(), 60)).Returns(2);
            cacheService.Setup(x => x.Get("t1", () => selfEmploymentService.Object.GetAll().Count(), 60)).Returns(2);
            var infoViewModel = new Mock<InfoViewModel>();

            // Act
            PartialViewResult result = controller.Information(infoViewModel.Object) as PartialViewResult;

            // Assert
            Assert.IsInstanceOf<PartialViewResult>(result);
        }
    }
}
