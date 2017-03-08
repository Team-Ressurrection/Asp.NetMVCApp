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

        [Test]
        public void ReturnLoginViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:51763/Account/Login";
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");
            
            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<LoginViewModel>(viewResult.Model);
        }

        [Test]
        public void ReturnActionResult_WhenPasswordSignInAsyncIsSuccess()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync("gosho", "123456", true, false)).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:51763/Account/Login";
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            Task<ActionResult> actionResultTask = accController.Login(mockedViewModel.Object, url);

            // Assert
            Assert.IsNotNull(actionResultTask);
        }

        [Test]
        public void ReturnActionResult_WhenPasswordSignInAsyncIsLockedOut()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.LockedOut).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:51763/Account/Login";
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            Task<ActionResult> actionResultTask = accController.Login(mockedViewModel.Object, url);

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }

        [Test]
        public void ReturnActionResult_WhenPasswordSignInAsyncIsRequiresVerification()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.RequiresVerification).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:51763/Account/Login";
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            Task<ActionResult> actionResultTask = accController.Login(mockedViewModel.Object, url);

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }

        [Test]
        public void ReturnActionResult_WhenPasswordSignInAsyncIsFailure()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.Failure).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:51763/Account/Login";
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<LoginViewModel>(viewResult.Model);
        }
    }
}
