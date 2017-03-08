using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Models;
using SalaryCalculatorWeb.Controllers;
using SalaryCalculatorWeb.Models.ManageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.Controllers.ManageControllerTests
{
    [TestFixture]
    public class VerifyPhoneNumber_Should
    {
        [Test]
        public void ReturnVerifyPhoneNumberViewModel_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<VerifyPhoneNumberViewModel>();
            ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);
            manageController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = manageController.VerifyPhoneNumber(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<VerifyPhoneNumberViewModel>(viewResult.Model);
        }
    }
}
