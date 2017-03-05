using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using Moq;

using NUnit.Framework;

using SalaryCalculator.Data.Contracts;
using SalaryCalculator.Data.Repositories;
using SalaryCalculator.Tests.Mocks;

namespace SalaryCalculator.Tests.Data.Repository
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenDbContextParameterIsNull()
        {
            // Arrange
            ISalaryCalculatorDbContext nullableDbContext = null;

            // Act & Assert
            Assert.That(
                () => new SalaryCalculatorRepository<FakeEmployee>(nullableDbContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("The argument is null"));
        }

        [Test]
        public void Constructor_ShouldCreateInstanceCorrectly_WhenParameterIsSetCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ISalaryCalculatorDbContext>();

            // Act
            var repository = new SalaryCalculatorRepository<FakeEmployee>(mockedDbContext.Object);

            // Assert
            Assert.IsInstanceOf(typeof(IRepository<FakeEmployee>), repository);
        }
    }
}