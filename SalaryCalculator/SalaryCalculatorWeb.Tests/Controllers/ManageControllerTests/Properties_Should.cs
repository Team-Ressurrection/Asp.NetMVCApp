using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Tests.Mocks;
using SalaryCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorWeb.Tests.Controllers.ManageControllerTests
{
    [TestFixture]
    public class Properties_Should
    {
        [Test]
        public void SetSignInManagerProperty_WhenOverloadConstructorIsInvoked()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            // Act
            ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.AreEqual(mockedSignInManager.Object, manageController.SignInManager);
        }

        [Test]
        public void SetUserManagerProperty_WhenOverloadConstructorIsInvoked()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            // Act
            ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.AreEqual(mockedUserManager.Object, manageController.UserManager);
        }
    }
}
