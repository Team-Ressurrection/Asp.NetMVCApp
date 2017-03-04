using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class GetGrossSalary_Should
    {
        [Test]
        public void ReturnSumOfAllParameters()
        {
            // Arrange
            var parameters = new List<decimal>() { 450, 500, 50 };

            // Act
            var payroll = new Payroll();

            // Assert
            Assert.AreEqual(parameters.Sum(), payroll.GetGrossSalary(parameters));
        }
    }
}
