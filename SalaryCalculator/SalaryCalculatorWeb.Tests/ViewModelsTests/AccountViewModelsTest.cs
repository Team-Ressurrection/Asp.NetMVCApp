using NUnit.Framework;
using SalaryCalculatorWeb.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SalaryCalculatorWeb.Tests.ViewModelsTests
{
    [TestFixture]
    public class AccountViewModelsTest
    {
        [Test]
        public void SendCodeViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var sendCodeModel = new SendCodeViewModel();

            // Act
            sendCodeModel.Providers = new Collection<SelectListItem>();
            sendCodeModel.RememberMe = true;
            sendCodeModel.ReturnUrl = "testUrl";
            sendCodeModel.SelectedProvider = "testSelectedProvider";

            // Assert
            Assert.AreEqual(new Collection<SelectListItem>(), sendCodeModel.Providers);
            Assert.AreEqual(true, sendCodeModel.RememberMe);
            Assert.AreEqual("testUrl", sendCodeModel.ReturnUrl);
            Assert.AreEqual("testSelectedProvider", sendCodeModel.SelectedProvider);
        }

        [Test]
        public void ExternalLoginConfirmationViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var externalConfirmationViewModel = new ExternalLoginConfirmationViewModel();

            // Act
            externalConfirmationViewModel.Email = "pesho@abv.bg";

            // Assert
            Assert.AreEqual("pesho@abv.bg", externalConfirmationViewModel.Email);
        }

        [Test]
        public void ForgotPasswordViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var forgotPasswordViewModel = new ForgotPasswordViewModel();

            // Act
            forgotPasswordViewModel.Email = "pesho@abv.bg";

            // Assert
            Assert.AreEqual("pesho@abv.bg", forgotPasswordViewModel.Email);
        }

        [Test]
        public void ForgotViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var forgotViewModel = new ForgotViewModel();

            // Act
            forgotViewModel.Email = "pesho@abv.bg";

            // Assert
            Assert.AreEqual("pesho@abv.bg", forgotViewModel.Email);
        }

        [Test]
        public void LoginViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var loginViewModel = new LoginViewModel();

            // Act
            loginViewModel.Email = "pesho@abv.bg";
            loginViewModel.Password = "123456";
            loginViewModel.RememberMe = true;

            // Assert
            Assert.AreEqual("pesho@abv.bg", loginViewModel.Email);
            Assert.AreEqual("123456", loginViewModel.Password);
            Assert.AreEqual(true, loginViewModel.RememberMe);
        }

        [Test]
        public void RegisterViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var registerViewModel = new RegisterViewModel();

            // Act
            registerViewModel.Email = "pesho@abv.bg";
            registerViewModel.CompanyName = "Payroll";
            registerViewModel.CompanyAddress = "Al. Stamboliiski";
            registerViewModel.Password = "123456";
            registerViewModel.ConfirmPassword = "123456";

            // Assert
            Assert.AreEqual("pesho@abv.bg", registerViewModel.Email);
            Assert.AreEqual("Payroll", registerViewModel.CompanyName);
            Assert.AreEqual("Al. Stamboliiski", registerViewModel.CompanyAddress);
            Assert.AreEqual("123456", registerViewModel.Password);
            Assert.AreEqual("123456", registerViewModel.ConfirmPassword);
        }

        [Test]
        public void ResetPasswordViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var resetPasswordViewModel = new ResetPasswordViewModel();

            // Act
            resetPasswordViewModel.Email = "pesho@abv.bg";
            resetPasswordViewModel.Password = "123456";
            resetPasswordViewModel.ConfirmPassword = "123456";
            resetPasswordViewModel.Code = "something";

            // Assert
            Assert.AreEqual("pesho@abv.bg", resetPasswordViewModel.Email);
            Assert.AreEqual("123456", resetPasswordViewModel.Password);
            Assert.AreEqual("123456", resetPasswordViewModel.ConfirmPassword);
            Assert.AreEqual("something", resetPasswordViewModel.Code);
        }

        [Test]
        public void VerifyCodeViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var verifyCodeViewModel = new VerifyCodeViewModel();

            // Act
            verifyCodeViewModel.Provider = "provider";
            verifyCodeViewModel.RememberBrowser = true;
            verifyCodeViewModel.RememberMe = true;
            verifyCodeViewModel.Code = "something";
            verifyCodeViewModel.ReturnUrl = "Account/Login";

            // Assert
            Assert.AreEqual("provider", verifyCodeViewModel.Provider);
            Assert.AreEqual(true, verifyCodeViewModel.RememberBrowser);
            Assert.AreEqual(true, verifyCodeViewModel.RememberMe);
            Assert.AreEqual("something", verifyCodeViewModel.Code);
            Assert.AreEqual("Account/Login", verifyCodeViewModel.ReturnUrl);
        }
    }
}