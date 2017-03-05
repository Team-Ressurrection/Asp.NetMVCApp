using Moq;
using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void GetById_ShouldInvokeOnlyOnce()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();

            var userService = new UserService(mockedRepository.Object);

            var user = new FakeUser();
            user.Id = "abcdefgh";

            // Act
            userService.Create(user);

            userService.GetById(user.Id);

            // Assert
            mockedRepository.Verify(r => r.GetById(user.Id), Times.Once);
        }
    }
}