using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NUnit.Framework;
using SalaryCalculatorWeb.Models.AccountViewModels;
using SalaryCalculatorWeb.Models.ManageViewModels;
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
    public class ManageViewModelsTest
    {
        [Test]
        public void AddPhoneNumberViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var addPhoneNumberViewModel = new AddPhoneNumberViewModel();

            // Act
            addPhoneNumberViewModel.Number = "0888102030";

            // Assert
            Assert.AreEqual("0888102030", addPhoneNumberViewModel.Number);
        }

        [Test]
        public void ChangePasswordViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var changePasswordViewModel = new ChangePasswordViewModel();

            // Act
            changePasswordViewModel.ConfirmPassword = "123456";
            changePasswordViewModel.OldPassword = "321";
            changePasswordViewModel.NewPassword = "123456";

            // Assert
            Assert.AreEqual("123456", changePasswordViewModel.ConfirmPassword);
            Assert.AreEqual("321", changePasswordViewModel.OldPassword);
            Assert.AreEqual("123456", changePasswordViewModel.NewPassword);
        }

        [Test]
        public void ConfigureTwoFactorViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var configureTwoFactorViewModel = new ConfigureTwoFactorViewModel();

            // Act
            configureTwoFactorViewModel.Providers = new Collection<SelectListItem>();
            configureTwoFactorViewModel.SelectedProvider = "selectedProvider";

            // Assert
            Assert.AreEqual(new Collection<SelectListItem>(), configureTwoFactorViewModel.Providers);
            Assert.AreEqual("selectedProvider", configureTwoFactorViewModel.SelectedProvider);
        }

        [Test]
        public void FactorViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var factorViewModel = new FactorViewModel();

            // Act
            factorViewModel.Purpose = "randomPurpose";

            // Assert
            Assert.AreEqual("randomPurpose", factorViewModel.Purpose);
        }

        [Test]
        public void IndexViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var indexViewModel = new IndexViewModel();

            // Act
            indexViewModel.BrowserRemembered = true;
            indexViewModel.HasPassword = true;
            indexViewModel.Logins = new List<UserLoginInfo>();
            indexViewModel.PhoneNumber = "0888203040";
            indexViewModel.TwoFactor = true;

            // Assert
            Assert.AreEqual(true, indexViewModel.BrowserRemembered);
            Assert.AreEqual(true, indexViewModel.HasPassword);
            Assert.AreEqual(true, indexViewModel.TwoFactor);
            Assert.AreEqual(new List<UserLoginInfo>(), indexViewModel.Logins);
            Assert.AreEqual("0888203040", indexViewModel.PhoneNumber);
        }

        [Test]
        public void ManageLoginsViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var manageLoginsViewModel = new ManageLoginsViewModel();

            // Act
            manageLoginsViewModel.CurrentLogins = new List<UserLoginInfo>();
            manageLoginsViewModel.OtherLogins =   new List<AuthenticationDescription>();

            // Assert
            Assert.AreEqual(new List<UserLoginInfo>(),manageLoginsViewModel.CurrentLogins);
            Assert.AreEqual(new List<AuthenticationDescription>(), manageLoginsViewModel.OtherLogins);
        }

        [Test]
        public void SetPasswordViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var setPasswordViewModel = new SetPasswordViewModel();

            // Act
            setPasswordViewModel.NewPassword = "123456";
            setPasswordViewModel.ConfirmPassword = "123456";

            // Assert
            Assert.AreEqual("123456", setPasswordViewModel.NewPassword);
            Assert.AreEqual("123456", setPasswordViewModel.ConfirmPassword);
        }

        [Test]
        public void VerifyPhoneNumberViewModel_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            var verifyPhoneNumberViewModel = new VerifyPhoneNumberViewModel();

            // Act
            verifyPhoneNumberViewModel.Code = "something";
            verifyPhoneNumberViewModel.PhoneNumber = "0888797979";

            // Assert
            Assert.AreEqual("something", verifyPhoneNumberViewModel.Code);
            Assert.AreEqual("0888797979", verifyPhoneNumberViewModel.PhoneNumber);
        }
    }
}