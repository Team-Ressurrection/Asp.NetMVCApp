using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

namespace SalaryCalculatorWeb.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstance_WhenDefaultConstructorIsInvoked()
        {
            // Arrange & Act
            AccountController accController = new AccountController();

            // Assert
            Assert.IsInstanceOf<AccountController>(accController);
        }

        [Test]
        public void CreateInstance_WhenOverloadConstructorIsInvoked()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            // Act
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.IsInstanceOf<AccountController>(accController);
        }
    }
}
