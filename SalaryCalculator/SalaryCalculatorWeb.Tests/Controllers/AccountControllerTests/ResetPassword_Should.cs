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

        [Test]
        public void ReturnResetPasswordViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<ResetPasswordViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.ResetPassword(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<ResetPasswordViewModel>(viewResult.Model);
        }

        [Test]
        public void ReturnActionResult_WhenModelStateIsValidAndUserIsNull()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<ResetPasswordViewModel>();
            mockedViewModel.SetupProperty(x => x.Email, "pesho@abv.bg");
            mockedViewModel.SetupProperty(x => x.Code, "1234");
            mockedViewModel.SetupProperty(x => x.Password, "123456");

            var user = new User() { Id = "1", Email = mockedViewModel.Object.Email };
            mockedUserManager.Setup(x => x.FindByNameAsync(mockedViewModel.Object.Email)).ReturnsAsync(user);

            mockedUserManager.Setup(x => x.ResetPasswordAsync(user.Id, mockedViewModel.Object.Code, mockedViewModel.Object.Password)).ReturnsAsync(IdentityResult.Success).Verifiable();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.ResetPassword(mockedViewModel.Object);
            actionResultTask.Wait();
            //var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }
    }
}
