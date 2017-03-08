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
    public class ForgotPassword_Should
    {
        [Test]
        public void ReturnViewResult_WhenIsCalled()
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.ForgotPassword() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnForgotPasswordViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<ForgotPasswordViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.ForgotPassword(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<ForgotPasswordViewModel>(viewResult.Model);
        }

        [Test]
        public void ReturnForgotPasswordConfirmationViewName_WhenModelStateIsValidAndUserIsNull()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<ForgotPasswordViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.ForgotPassword(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.AreEqual("ForgotPasswordConfirmation",viewResult.ViewName);
        }
    }
}
