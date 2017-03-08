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
    public class AddPhoneNumber_Should
    {
        [Test]
        public void ReturnViewResult_WhenRegisterIsCalled()
        {
            // Arrange
            ManageController manageController = new ManageController();

            // Act
            ViewResult result = manageController.AddPhoneNumber() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnAddPhoneNumberViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<AddPhoneNumberViewModel>();
            ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);
            manageController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = manageController.AddPhoneNumber(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<AddPhoneNumberViewModel>(viewResult.Model);
        }

        [Test]
        public void ReturnAddPhoneNumberViewModel_WhenModelStateIsValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<AddPhoneNumberViewModel>();
            ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);
            string code = "testcode";
            mockedUserManager.Setup(x => x.GenerateChangePhoneNumberTokenAsync(null, null)).ReturnsAsync(code).Verifiable();

            // Act
            var actionResultTask = manageController.AddPhoneNumber(mockedViewModel.Object);

            // Assert
            mockedUserManager.Verify(x => x.GenerateChangePhoneNumberTokenAsync("111", "0888112233"), Times.AtMostOnce);
        }
    }
}
