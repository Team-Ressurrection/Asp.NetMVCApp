using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.RemunerationBillModels
{
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfRemunerationBillCorrectly()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.IsInstanceOf(typeof(RemunerationBill), bill);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_IdProperty()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.AreEqual(0, bill.Id);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_PersonalInsuranceProperty()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.AreEqual(0.0m, bill.PersonalInsurance);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_NetWageProperty()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.AreEqual(0.0m, bill.NetWage);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_IncomeTaxProperty()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.AreEqual(0.0m, bill.IncomeTax);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_GrossSalaryProperty()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.AreEqual(0.0m, bill.GrossSalary);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_SocialSecurityIncomeProperty()
        {
            // Arrange & Act
            var bill = new RemunerationBill();

            // Assert
            Assert.AreEqual(0.0m, bill.SocialSecurityIncome);
        }
    }
}
