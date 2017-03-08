using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
    public class VerifyCode
    {
        [Test]
        public void ReturnViewNameWithError_WhenHasBeenVerifiedAsyncIsFalse()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);
            string provider = "lskadjlaskdjlaskjdlkasjd";
            string url = "localhost";
            bool rememberMe = false;

            // Act
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            var actionResultTask = accController.VerifyCode(provider, url, rememberMe);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [Test]
        public void ReturnViewModelWithTypeVerifyCodeViewModel_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedModel = new Mock<VerifyCodeViewModel>();
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");
            
            // Act
            var actionResultTask = accController.VerifyCode(mockedModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<VerifyCodeViewModel>(viewResult.Model);
        }

        [Test]
        public void ReturnActionResult_WhenTwoFactorSignInAsyncIsSuccess()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.TwoFactorSignInAsync("gosho", "123456", true, false)).Verifiable();

            var mockedViewModel = new Mock<VerifyCodeViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            Task<ActionResult> actionResultTask = accController.VerifyCode(mockedViewModel.Object);

            // Assert
            Assert.IsNotNull(actionResultTask);
        }

        [Test]
        public void ReturnActionResult_WhenTwoFactorSignInAsyncIsLockedOut()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.TwoFactorSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.LockedOut).Verifiable();

            var mockedViewModel = new Mock<VerifyCodeViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            Task<ActionResult> actionResultTask = accController.VerifyCode(mockedViewModel.Object);

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }

        [Test]
        public void ReturnActionResult_WhenTwoFactorSignInAsyncIsFailure()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.TwoFactorSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.Failure).Verifiable();

            var mockedViewModel = new Mock<VerifyCodeViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.VerifyCode(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<VerifyCodeViewModel>(viewResult.Model);
        }
    }
}
