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
    public class ResetPassword_Should
    {
        [TestCase("123456")]
        public void ReturnViewResult_WhenCodeIsSet(string code)
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.ResetPassword(code) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase(null)]
        public void ReturnViewResultWithError_WhenCodeIsNull(string code)
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.ResetPassword(code) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }
    }
}
