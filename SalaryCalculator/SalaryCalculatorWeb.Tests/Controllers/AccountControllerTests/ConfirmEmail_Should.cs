using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Models;
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
    public class ConfirmEmail_Should
    {
        [Test]
        public void ReturnViewNameWithError_WhenUserIdIsNull()
        {
            // Arrange
            var accController = new AccountController();
            string userId = null;
            string code = "something";

            // Act
            var actionResultTask = accController.ConfirmEmail(userId, code);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void ReturnViewNameWithError_WhenCodeIsNull()
        {
            // Arrange
            var accController = new AccountController();
            string userId = "lskadjlaskdjlaskjdlkasjd";
            string code = null;

            // Act
            var actionResultTask = accController.ConfirmEmail(userId, code);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void ReturnViewNameConfirmEmail_WhenAllParametersAreSetCorrectly()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);
            string userId = "lskadjlaskdjlaskjdlkasjd";
            string code = "something";
            IdentityResult result = IdentityResult.Success;
            mockedUserManager.Setup(x => x.ConfirmEmailAsync(userId, code)).ReturnsAsync(result).Verifiable();

            // Act
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            var actionResultTask = accController.ConfirmEmail(userId, code);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("ConfirmEmail", viewResult.ViewName);
        }

        [Test]
        public void ReturnViewNameError_WhenIdentityResultIsFalse()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);
            string userId = "lskadjlaskdjlaskjdlkasjd";
            string code = "something";
            IdentityResult result = new IdentityResult();
            mockedUserManager.Setup(x => x.ConfirmEmailAsync(userId, code)).ReturnsAsync(result).Verifiable();

            // Act
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            var actionResultTask = accController.ConfirmEmail(userId, code);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("Error", viewResult.ViewName);
        }
    }
}
