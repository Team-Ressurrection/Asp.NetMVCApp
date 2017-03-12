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
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllServicesArePassedCorrectly()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();

            // Act & Assert
            Assert.IsInstanceOf<HomeController>(new HomeController(cacheService.Object, userService.Object, paycheckService.Object, billService.Object, selfEmploymentService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCacheServiceIsNull()
        {
            // Arrange
            ICacheService cacheService = null;
            var userService = new Mock<IUserService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(cacheService, userService.Object, paycheckService.Object, billService.Object, selfEmploymentService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPaycheckServiceIsNull()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            IEmployeePaycheckService paycheckService = null;
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(cacheService.Object, userService.Object, paycheckService, billService.Object, selfEmploymentService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            IUserService userService = null;
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            var selfEmploymentService = new Mock<ISelfEmploymentService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(cacheService.Object, userService, paycheckService.Object, billService.Object, selfEmploymentService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBillServiceIsNull()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            IRemunerationBillService billService = null;
            var selfEmploymentService = new Mock<ISelfEmploymentService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(cacheService.Object, userService.Object, paycheckService.Object, billService, selfEmploymentService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenSelfEmploymentServiceIsNull()
        {
            // Arrange
            var cacheService = new Mock<ICacheService>();
            var userService = new Mock<IUserService>();
            var paycheckService = new Mock<IEmployeePaycheckService>();
            var billService = new Mock<IRemunerationBillService>();
            ISelfEmploymentService selfEmploymentService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(cacheService.Object, userService.Object, paycheckService.Object, billService.Object, selfEmploymentService));
        }
    }
}
