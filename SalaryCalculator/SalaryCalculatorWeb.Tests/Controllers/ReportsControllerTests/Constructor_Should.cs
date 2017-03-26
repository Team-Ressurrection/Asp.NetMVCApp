using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorWeb.Tests.Controllers.ReportsControllerTests
{
    [TestFixture]
   public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenAllParametersArePassedCorrectly()
        {
            // Arrange
            var mockedPaycheckService = new Mock<IEmployeePaycheckService>();
            var mockedBillService = new Mock<IRemunerationBillService>();

            // Act & Assert
            Assert.IsInstanceOf<ReportsController>(new ReportsController(mockedPaycheckService.Object, mockedBillService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmployeePaycheckServiceIsNull()
        {
            // Arrange
            IEmployeePaycheckService mockedPaycheckService = null;
            var mockedBillService = new Mock<IRemunerationBillService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(()=>new ReportsController(mockedPaycheckService, mockedBillService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRemunerationBillServiceIsNull()
        {
            // Arrange
            var mockedPaycheckService = new Mock<IEmployeePaycheckService>();
            IRemunerationBillService mockedBillService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ReportsController(mockedPaycheckService.Object, mockedBillService));
        }
    }
}
