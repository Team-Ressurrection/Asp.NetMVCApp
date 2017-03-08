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
    public class Register_Should
    {
        [Test]
        public void ReturnViewResult_WhenRegisterIsCalled()
        {
            // Arrange
            AccountController accController = new AccountController();

            // Act
            ViewResult result = accController.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnRegisterViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<RegisterViewModel>();
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.Register(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<RegisterViewModel>(viewResult.Model);
        }
    }
}