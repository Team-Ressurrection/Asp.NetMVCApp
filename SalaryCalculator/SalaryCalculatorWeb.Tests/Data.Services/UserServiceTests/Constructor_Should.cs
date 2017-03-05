using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class UserServicesTests
    {
        [Test]
        public void Constructor_WhenValidParameterIsPassed_ShouldReturnNewInstance()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();

            // Act
            var userService = new UserService(mockedRepository.Object);

            // Assert
            Assert.IsInstanceOf(typeof(UserService), userService);
        }
    }
}
