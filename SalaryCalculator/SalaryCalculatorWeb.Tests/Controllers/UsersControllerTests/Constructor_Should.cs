using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Utilities.Factories;
using SalaryCalculatorWeb.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorWeb.Tests.Controllers.UsersControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act
            UsersController usersController = new UsersController(mockedMapService.Object, mockedUserService.Object, mockedPagerFactory.Object);

            // Assert
            Assert.IsInstanceOf<UsersController>(usersController); 
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterMapServiceIsNullable()
        {
            // Arrange
            IMapService mockedMapService = null;
            var mockedUserService = new Mock<IUserService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(()=> new UsersController(mockedMapService, mockedUserService.Object, mockedPagerFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterUserServiceIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            IUserService mockedUserService = null;
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersController(mockedMapService.Object, mockedUserService, mockedPagerFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterPagerFactoryIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedUserService = new Mock<IUserService>();
            IPagerFactory mockedPagerFactory = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersController(mockedMapService.Object, mockedUserService.Object, mockedPagerFactory));
        }
    }
}
