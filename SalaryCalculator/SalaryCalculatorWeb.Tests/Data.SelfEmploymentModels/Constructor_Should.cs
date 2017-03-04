using NUnit.Framework;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Tests.Data.SelfEmploymentModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfSelfEmploymentCorrectly()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.IsInstanceOf(typeof(SelfEmployment), selfEmpl);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldSetPropertyRemunerationBillsAsEmptyHashSet()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.IsAssignableFrom(typeof(DateTime), selfEmpl.CreatedDate);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IdProperty()
        {
            // Arrange & Act
            var selfEmpl = new Employee();

            // Assert
            Assert.AreEqual(0, selfEmpl.Id);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_EmployeeIdProperty()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.AreEqual(0, selfEmpl.EmployeeId);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossSalaryProperty()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.AreEqual(0m, selfEmpl.GrossSalary);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IncomeTaxProperty()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.AreEqual(0m, selfEmpl.IncomeTax);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_NetWageProperty()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.AreEqual(0m, selfEmpl.NetWage);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_PersonalInsuranceProperty()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.AreEqual(0m, selfEmpl.PersonalInsurance);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_SocialSecurityIncomeProperty()
        {
            // Arrange & Act
            var selfEmpl = new SelfEmployment();

            // Assert
            Assert.AreEqual(0m, selfEmpl.SocialSecurityIncome);
        }
    }
}