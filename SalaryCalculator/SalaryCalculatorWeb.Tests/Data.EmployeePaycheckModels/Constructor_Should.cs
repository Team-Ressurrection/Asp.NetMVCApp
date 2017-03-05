using System;
using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.EmployeePaycheckModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfEmployeePaycheckCorrectly()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.IsInstanceOf(typeof(EmployeePaycheck), paycheckService);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldSetPropertyRemunerationBillsAsEmptyHashSet()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.IsAssignableFrom(typeof(DateTime), paycheckService.CreatedDate);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IdProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0, paycheckService.Id);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_EmployeeIdProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0, paycheckService.EmployeeId);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossFixedBonusProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.GrossFixedBonus);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossNonFixedBonusProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.GrossNonFixedBonus);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_GrossSalaryProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.GrossSalary);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_IncomeTaxProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.IncomeTax);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_NetWageProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.NetWage);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_PersonalInsuranceProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.PersonalInsurance);
        }

        [Test]
        public void ConstructorWhenIsInvoked_ShouldNotSet_SocialSecurityIncomeProperty()
        {
            // Arrange & Act
            var paycheckService = new EmployeePaycheck();

            // Assert
            Assert.AreEqual(0m, paycheckService.SocialSecurityIncome);
        }
    }
}
