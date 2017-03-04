using NUnit.Framework;

using SalaryCalculator.Utilities.Calculations;

namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class GetIncomeTax_Should
    {
        [Test]
        public void ReturnCorrectValueOfIncomeTax()
        {
            // Arrange
            var salary = 1000;
            var insurance = 100;

            // Act
            var payroll = new Payroll();

            // Assert
            Assert.AreEqual(90m, payroll.GetIncomeTax(salary, insurance));
        }
    }
}
