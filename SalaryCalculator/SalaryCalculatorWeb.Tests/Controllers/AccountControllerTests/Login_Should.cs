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
    public class Login_Should
    {
        [TestCase("http://localhost:51763/Account/Login")]
        public void ReturnViewResult_WhenUrlIsSet(string url)
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.Login(url) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase("http://localhost:51763/Account/Login")]
        public void ReturnViewBagResult_WithProvidedUrl(string url)
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.Login(url) as ViewResult;

            // Assert
            Assert.AreEqual(url, result.ViewBag.ReturnUrl);
        }
    }
}
