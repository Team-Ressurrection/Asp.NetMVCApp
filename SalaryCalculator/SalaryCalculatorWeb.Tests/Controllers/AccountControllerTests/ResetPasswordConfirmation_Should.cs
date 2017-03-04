using NUnit.Framework;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class ResetPasswordConfirmation_Should
    {
        [Test]
        public void ReturnViewResult_WhenIsSet()
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.ResetPasswordConfirmation() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
