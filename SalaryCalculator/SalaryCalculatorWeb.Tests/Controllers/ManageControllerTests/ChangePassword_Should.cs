using NUnit.Framework;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.ManageControllerTests
{
    [TestFixture]
    public class ChangePassword_Should
    {
        [Test]
        public void ReturnViewResult_WhenIsCalled()
        {
            // Arrange
            ManageController manageController = new ManageController();

            // Act
            ViewResult result = manageController.ChangePassword() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
