using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Models;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class SendCode_Should
    {
        [Test]
        public void ReturnViewNameWithError_WhenUserIdIsNull()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);
            string url = "localhost";
            bool rememberMe = false;

            // Act
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            var actionResultTask = accController.SendCode(url, rememberMe);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void ReturnViewResult_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<SendCodeViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.SendCode(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
        }

        [Test]
        public void ReturnViewNameWithError_WhenSendTwoFactorCodeAsyncIsFalse()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<SendCodeViewModel>();
            mockedViewModel.SetupProperty(x => x.SelectedProvider, "testProvider");
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            mockedSignInManager.Setup(x => x.SendTwoFactorCodeAsync(mockedViewModel.Object.SelectedProvider)).ReturnsAsync(false).Verifiable();
            // Act
            var actionResultTask = accController.SendCode(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("Error",viewResult.ViewName);
        }

        [Test]
        public void ReturnViewNameWithError_WhenSendTwoFactorCodeAsyncIsTrue()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<SendCodeViewModel>();
            mockedViewModel.SetupProperty(x => x.SelectedProvider, "testProvider");
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            mockedSignInManager.Setup(x => x.SendTwoFactorCodeAsync(mockedViewModel.Object.SelectedProvider)).ReturnsAsync(true).Verifiable();
            // Act
            var actionResultTask = accController.SendCode(mockedViewModel.Object);
            actionResultTask.Wait();

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }
    }
}
