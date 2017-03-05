using System.Collections.Generic;

using NUnit.Framework;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Tests.Data.EmployeeModels
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WhenConstructorIsInvoked_ShouldSetInstanceOfEmployeeCorrectly()
        {
            // Arrange & Act
            var employee = new Employee();

            // Assert
            Assert.IsInstanceOf(typeof(Employee), employee);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldSetPropertyRemunerationBillsAsEmptyHashSet()
        {
            // Arrange & Act
            var employee = new Employee();

            // Assert
            Assert.AreEqual(new HashSet<RemunerationBill>(), employee.RemunerationBills);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_IdProperty()
        {
            // Arrange & Act
            var empl = new Employee();

            // Assert
            Assert.AreEqual(0, empl.Id);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_FirstNameProperty()
        {
            // Arrange & Act
            var empl = new Employee();

            // Assert
            Assert.AreEqual(null, empl.FirstName);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_MiddleNameProperty()
        {
            // Arrange & Act
            var empl = new Employee();

            // Assert
            Assert.AreEqual(null, empl.MiddleName);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_LastNameProperty()
        {
            // Arrange & Act
            var empl = new Employee();

            // Assert
            Assert.AreEqual(null, empl.LastName);
        }

        [Test]
        public void WhenConstructorIsInvoked_ShouldNotSet_PersonalIdProperty()
        {
            // Arrange & Act
            var empl = new Employee();

            // Assert
            Assert.AreEqual(null, empl.PersonalId);
        }
    }
}
