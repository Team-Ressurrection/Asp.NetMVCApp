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

namespace SalaryCalculatorWeb.Tests.Controllers.AdminArea.PaycheckControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedEmployeePaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act
            PaychecksController PaychecksController = new PaychecksController(mockedMapService.Object, mockedPagerFactory.Object, mockedEmployeePaycheckService.Object);

            // Assert
            Assert.IsInstanceOf<PaychecksController>(PaychecksController);
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterMapServiceIsNullable()
        {
            // Arrange
            IMapService mockedMapService = null;
            var mockedEmployeePaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PaychecksController(mockedMapService, mockedPagerFactory.Object, mockedEmployeePaycheckService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterUserServiceIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            IEmployeePaycheckService mockedEmployeePaycheckService = null;
            var mockedPagerFactory = new Mock<IPagerFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PaychecksController(mockedMapService.Object, mockedPagerFactory.Object, mockedEmployeePaycheckService));
        }

        [Test]
        public void ThrowArgumentNullException_WhenParameterPagerFactoryIsNullable()
        {
            // Arrange
            var mockedMapService = new Mock<IMapService>();
            var mockedEmployeePaycheckService = new Mock<IEmployeePaycheckService>();
            IPagerFactory mockedPagerFactory = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PaychecksController(mockedMapService.Object, mockedPagerFactory, mockedEmployeePaycheckService.Object));
        }
    }
}
