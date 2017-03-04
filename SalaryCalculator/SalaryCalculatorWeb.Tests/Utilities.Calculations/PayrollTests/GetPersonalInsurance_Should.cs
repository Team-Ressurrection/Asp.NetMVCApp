using NUnit.Framework;

using SalaryCalculator.Utilities.Calculations;


namespace SalaryCalculator.Tests.Utilities.Calculations.PayrollTests
{
    [TestFixture]
    public class GetPersonalInsurance_Should
    {
        [TestCase(1000, 0.129)]
        public void ReturnCorrectValue_WhenParametersArePassed(decimal salary, decimal percent)
        {
            // Arrange
            var payroll = new Payroll();

            // Act & Assert
            Assert.AreEqual(salary * percent, payroll.GetPersonalInsurance(salary));
        }
    }
}
