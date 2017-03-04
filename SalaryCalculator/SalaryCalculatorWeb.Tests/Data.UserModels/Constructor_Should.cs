using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.UserModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenCreatingNewUser_ShouldInheritsIdentityUserClass()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsInstanceOf(typeof(User), user);
        }

        [Test]
        public void WhenCreatingNewUser_ShouldHavePropertyCompanyName()
        {
            // Arrange
            var user = new User();

            // Act
            user.CompanyName = "Firma";

            // Assert
            Assert.IsAssignableFrom(typeof(string), user.CompanyName);
        }

        [Test]
        public void WhenCreatingNewUser_ShouldHavePropertyCompanyAddress()
        {
            // Arrange
            var user = new User();

            // Act
            user.CompanyAddress = "bulevard Bulgaria";

            // Assert
            Assert.IsAssignableFrom(typeof(string), user.CompanyAddress);
        }
    }
}
