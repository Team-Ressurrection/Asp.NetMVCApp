using Microsoft.AspNet.Identity.EntityFramework;

using NUnit.Framework;

using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.SalaryCalculatorDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorWhenPassed_ShouldCreateInstance()
        {
            // Arrange & Act
            var dbContext = new SalaryCalculatorDbContext();

            // Assert
            Assert.IsInstanceOf(typeof(IdentityDbContext<User>), dbContext);
        }
    }
}
