using Moq;
using NUnit.Framework;
using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Services.Contracts;
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

            // Act
            UsersController usersController = new UsersController(mockedMapService.Object, mockedUserService.Object);

            // Assert
            Assert.IsInstanceOf<UsersController>(usersController); 
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterMapServiceIsNullable()
        {
            // Arrange
            IMapService mockedMapService = null;
            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(()=> new UsersController(mockedMapService, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterUserServiceIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            IUserService mockedUserService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersController(mockedMapService.Object, mockedUserService));
        }
    }
}
