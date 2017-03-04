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
    public class ForgotPasswordConfirmation_Should
    {
        [Test]
        public void ReturnViewResult_WhenIsCalled()
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.ForgotPasswordConfirmation() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
